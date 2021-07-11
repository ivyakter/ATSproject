let Audit = new Vue({
    el: '#Audit',
    data: {
        isMassage: false,
        errorMassage: "",
        ClassStatus: "",
        search: "",
        Audit: {},
        AuditList: [],
        DepartmentList: [],
        IsShow: true,
        IsShowCancel: false,
    },
    methods: {
        Create() {
            axios({
                method: 'post',
                url: '/Audit/Create',
                data: this.Audit
            }).then(response => {
             
                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000);
                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The Audit Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "2") {
                    this.errorMassage = "Audit Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "Success") {
                    this.errorMassage = "Audit Create Success ";
                    this.ClassStatus = ['alert-success'];
                    this.GetAll();
                    this.Audit = {};
                    this.Audit.departmentId = 0;
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }
            })
        },

        Update() {
            axios({
                method: 'post',
                url: '/Audit/Update',
                data: this.Audit
            }).then(response => {

                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)

                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The Audit Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


                if (response.data == "2") {
                    this.errorMassage = "Audit Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "Success") {
                    this.errorMassage = "Audit Create Success ";
                    this.ClassStatus = ['alert-success'];
                    this.GetAll();
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }
            })
        },

        GetAll() {
            axios({
                method: 'get',
                url: '/Audit/GetAll',
            }).then(response => {
                this.AuditList = response.data;
                console.log(this.AuditList);
            })
        },
        GetAllDepartment() {
            axios({
                method: 'get',
                url: '/Department/GetAll',
            }).then(response => {
                this.DepartmentList = response.data;
            })
        },
        Edit(id) {
            this.IsShow = false;
            this.IsShowCancel = true;
            axios.get('/Audit/Edit/' + id).then(response => {
                this.Audit = {
                    id: response.data.id,
                    name: response.data.name,
                    departmentId: response.data.departmentId,
                }
            });
        },
        Delete: function (name, id) {
            var r = confirm("Do You Want to Delete " + id + "-" + name + " ?");
            if (r === true) {
                axios.delete('/Audit/Remove/' + id).then(response => {
                    this.Cancel();
                    this.GetAll();
                });
            }
        },
        Cancel() {
            this.IsShow = true;
            this.IsShowCancel = false;
            this.Audit = {};
            this.Audit.departmentId = 0;
        },
    },
    mounted() {
        this.GetAll();
        this.GetAllDepartment();
        this.Audit.departmentId = 0;
    },
    computed: {
        filteredAuditList: function () {
            var vm = this;
            return this.AuditList.filter(function (item) {
                return item.name.toLowerCase().indexOf(vm.search.toLowerCase()) >= 0

            });
        }
    }
})