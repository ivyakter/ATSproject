let Department = new Vue({
    el: '#Department',
    data: {
        isMassage: false,
        errorMassage: "",
        ClassStatus: "",
        search: "",
        Department: {},
        DepartmentList: [],

        IsShow: true,
        IsShowCancel: false,
    },
    methods: {
        Create() {

            axios({
                method: 'post',
                url: '/Department/Create',
                data: this.Department
            }).then(response => {

                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The Department Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "2") {
                    this.errorMassage = "Department Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "Success") {
                    this.errorMassage = "Department Create Success ";
                    this.ClassStatus = ['alert-success'];
                    this.GetAll();
                    this.Department = {};
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }
            })
        },

        Update() {
            axios({
                method: 'post',
                url: '/Department/Update',
                data: this.Department
            }).then(response => {

                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)

                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The Department Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "2") {
                    this.errorMassage = "Department Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "Success") {
                    this.errorMassage = "Department Create Success ";
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
                url: '/Department/GetAll',
            }).then(response => {
                this.DepartmentList = response.data;
                //console.log(this.Requirement);
            })
        },

        Edit(id) {
            this.IsShow = false;
            this.IsShowCancel = true;
            axios.get('/Department/Edit/' + id).then(response => {
                this.Department = {
                    id: response.data.id,
                    name: response.data.name,
                }

            });
        },
        Delete: function (name, id) {
            var r = confirm("Do You Want to Delete " + id + "-" + name + " ?");
            if (r === true) {
                axios.delete('/Department/Remove/' + id).then(response => {
                    this.Cancel();
                    this.GetAll();
                });
            }
        },
        Cancel() {
            this.IsShow = true;
            this.IsShowCancel = false;
            this.Department = {};
        },
    },
    mounted() {
        this.GetAll();
    },
    computed: {
        filteredDepartmentList: function () {
            var vm = this;
            return this.DepartmentList.filter(function (item) {
                return item.name.toLowerCase().indexOf(vm.search.toLowerCase()) >= 0



            });
        }
    }
})