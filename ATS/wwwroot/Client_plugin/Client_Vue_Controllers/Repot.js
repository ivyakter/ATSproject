var Repot = new Vue({
    el: '#Repot',
    data: {
        AuditList: [],
        DepartmentList: [],
        ProjectList: [],
        DivisionList: [],
        DistricList: [],
        UpazilaList: [],
        filterAudit: [],
        ObjectionList: [],
        viewobjectionlist: [],
        finddata: [],

        isActive: false,
        isproject: false,
        isAudit: true,
        isDivision: true,
        isDistric: true,
        showsClear: false,
        search: "",
        startDate: null,
        endDate: null,
        Aduit: "Select Aduit",
        Departmentcselect: "Select Department",
        Projecselect: "Select Project",
        YearsSelect: "Select Years",
        DivisionSelect: "Select Division",
        DistrictSelect: "Select  District",
        UpazilaSelect: "Select  Upazila",
        FilterByDepartment: "",
        FilterByAudit: "",
        FilterByYears: "",
        FilterByyears: "",
        FilterByDivision: "",
        FilterByDistrict: "",
        FilterByUpazila: "",
        search: "",
        startDate: null,
        endDate: null,
        filterObject: { departmentId: 0, auditId: 0, years: '', divisionId: 0, districtId: 0, upazilaId: 0 },
        a: true,
    },
    methods: {
        printinduvisul(){
            var originalContents = document.body.innerHTML;
            var printContents = document.getElementById('printinduvisul').innerHTML;


            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
            setTimeout("location.reload(true);", 1000);
        },

        print() {
            this.a = false;
            this.hideThTd = false;
            var originalContents = document.body.innerHTML;
            var printContents = document.getElementById('repotId').innerHTML;

            
            document.body.innerHTML = printContents;

            //table td: last - child { display: none };
            //table th: last - child { display: none };
            window.print();

            document.body.innerHTML = originalContents;
            setTimeout("location.reload(true);", 1000);


            //var el = document.getElementById("print");
            //newwin = window.open("");
            //newwin.document.write(el.outerHTML);
            //newwin.print();
            //newwin.close();
        },


        GetAllDepartment() {
            axios({
                method: 'get',
                url: '/Client/GetAllDepartmentforClientpage',
            }).then(response => {
                this.DepartmentList = response.data;

            })
        },

        filterDepartment(id, name) {


            if (id > 0) {
                this.isAudit = false;
                this.Departmentcselect = name;
                this.FilterByDepartment = id;
                this.filterObject.departmentId = id;
                this.filterObject.auditId = 0;
                this.databasefilter();
                axios.get('/Client/filterAudit/' + id).then(response => {
                    this.filterAudit = response.data;
                    this.Aduit = "Select  Aduit";
                })
            } else
                this.Departmentcselect = "Select Department";
            this.filterAudit = "";
        },

        Auditfilter(id, name) {
            if (id > 0) {
                this.filterObject.auditId = id;
                this.filterObject.departmentId = 0;
                this.databasefilter();
                this.FilterByAudit = id;
                this.Aduit = name;
            } else
                this.Aduit = "Select  Aduit";
        },


        GetAllProject() {
            axios({
                method: 'get',
                url: '/Client/GetAllProjectforClientpage',
            }).then(response => {
                this.ProjectList = response.data;
                //console.log(this.ProjectList);
            })
        },

        GetAllDivision() {
            axios({
                method: 'get',
                url: '/Client/GetAllDivisionforClientpage',
            }).then(response => {
                this.DivisionList = response.data;
                //console.log(this.DivisionList);

            })
        },



        filtterYears(years) {
            this.YearsSelect = years;
            this.FilterByYears = years;
            this.FilterByyears = String(this.FilterByYears);
            this.databasefilter();
            this.filterObject.years = years;
            this.filterObject.years = String(this.filterObject.years);

        },



        Division(id, name) {
            this.isDivision = false;
            this.DivisionSelect = name;
            this.FilterByDivision = id;
            this.filterObject.divisionId = id;
            this.filterObject.districtId = 0;
            this.databasefilter();
            axios.get('/Client/filterDistrict/' + id).then(response => {

                this.DistricList = response.data;
                //console.log(this.DistricList);
                this.District();
                this.Upzila();

            })
        },

        District(id, name) {

            if (id > 0) {
                this.isDistric = false;
                this.FilterByDistrict = id;
                this.DistrictSelect = name;
                this.filterObject.districtId = id;
                this.filterObject.upazilaId = 0;
                this.databasefilter();
                axios.get('/Client/filterUpazila/' + id).then(response => {

                    this.UpazilaList = response.data;
                    //console.log(this.UpazilaList);    
                    this.Upzila();
                })
            } else

                this.DistrictSelect = "Select  District";
            this.UpazilaList = "";
        },


        Upzila(id, name) {
            if (id > 0) {
                this.FilterByUpazila = id;
                this.UpazilaSelect = name;
                this.filterObject.upazilaId = id;
                this.databasefilter();
            } else
                this.UpazilaSelect = "Select  Upazila";
        },

        GettAllObjectionList() {
            axios({
                method: 'get',
                url: '/Client/ObjectionList',
            }).then(response => {
                this.finddata = response.data;

            })

        },

        viewObjectrion(id) {
            axios.get('/Client/viewfilterdata/' + id).then(response => {
                this.viewobjectionlist = response.data;
                console.log(this.viewobjectionlist);
            })
        },
        MainFilter(data) {
            this.FilterByDepartment = "All";
        },

        FlitterBymobileNo(date) {
            this.databasefilter();
        },

        FlitterByEndDate() {
            this.databasefilter();
        },

        FlitterByStartDate() {
            this.databasefilter();
        },
        databasefilter() {
            this.showsClear = true;
            axios({
                method: 'post',
                url: '/Client/combinefilter',
                data: this.filterObject
            }).then(response => {
                this.finddata = response.data;
                console.log(this.finddata);
            })
        },
        ClearAll() {
            setTimeout("location.reload(true);", 10);
        },
    },
    mounted() {

        this.GetAllDepartment();
        this.GetAllProject();
        this.GetAllDivision();
        this.GettAllObjectionList();
    },
    computed: {

        yearsList() {
            const year = new Date().getFullYear()
            return Array.from({ length: year - 1970 }, (value, index) => 1971 + index)
        },

    }
})