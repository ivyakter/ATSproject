let Department = new Vue({
    el: '#project',
    data: {
        IsShow: true,
        isMassage: false,
        errorMassage: "",
        ClassStatus: "",
        search: "",
        Project: {},
        PeojecttList: [],

        IsShow: true,
        IsShowCancel: false,
    },
    methods: {
        Create() {
            axios({
                method: 'post',
                url: '/Project/Create',
                data: this.Project
            }).then(response => {

                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)

                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The Project Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


                if (response.data == "2") {
                    this.errorMassage = "Project Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "Success") {
                    this.errorMassage = "Project Create Success ";
                    this.ClassStatus = ['alert-success'];
                    this.GetAll();
                    this.Project = {};
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


            })

        },

        Update() {

            axios({
                method: 'post',
                url: '/Project/Update',
                data: this.Project
            }).then(response => {
                console.log(response.data + "vvvvvvvv");

                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)

                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The Project Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


                if (response.data == "2") {
                    this.errorMassage = "Project Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "Success") {
                    this.errorMassage = "Project Update Success ";
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
                url: '/Project/GetAll',
            }).then(response => {
                this.PeojecttList = response.data;
                console.log(this.PeojecttList);
            })
        },

        Edit(id) {
            this.IsShow = false;
            this.IsShowCancel = true;
            axios.get('/Project/Edit/' + id).then(response => {
                this.Project = {
                    id: response.data.id,
                    name: response.data.name,
                }

            });
        },
        Delete: function (name, id) {
            var r = confirm("Do You Want to Delete " + id + "-" + name + " ?");
            if (r === true) {
                axios.delete('/Project/Remove/' + id).then(response => {
                    this.Cancel();
                    this.GetAll();
                });

            }
        },
        Cancel() {
            this.IsShow = true;
            this.IsShowCancel = false;
            this.Project = {};
        },


    },
    mounted() {
        this.GetAll();
    },
    computed: {
        filteredprojectList: function () {
            var Vmproject = this;
            return this.PeojecttList.filter(function (data) {
                return data.name.toLowerCase().indexOf(Vmproject.search.toLowerCase()) >= 0



            });
        }
    }
})
