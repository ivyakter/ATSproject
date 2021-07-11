let Division= new Vue({
    el:'#Division',
    data: {
        IsShow: true,
        isMassage: false,
        errorMassage: "",
        ClassStatus: "",
        search: "",
        Division:{},
        DivisionList: [],

    },
    methods: {
        Create() {

            axios({
                method: 'post',
                url: '/Division/Create',
                data: this.Division
            }).then(response => {

                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)

                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The Division Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


                if (response.data == "2") {
                    this.errorMassage = "Division Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "Success") {
                    this.errorMassage = "Division Create Success ";                  
                    this.ClassStatus = ['alert-success'];
                    this.GetAll();
                    this.Division = {};
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


            })

        },

        Update() {

            axios({
                method: 'post',
                url: '/Division/Update',
                data: this.Division
            }).then(response => {


                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)

                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The Division Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


                if (response.data == "2") {
                    this.errorMassage = "Division Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "Success") {
                    this.errorMassage = "Division Update Success ";
                    this.ClassStatus = ['alert-success'];
                    this.GetAll();
                    this.Division = {};
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


            })

        },

        GetAll() {
            axios({
                method: 'get',
                url: '/Division/GetAll',
            }).then(response => {
                this.DivisionList = response.data;
                //console.log(this.DivisionList);
            })
        },

        Edit(id) {
            this.IsShow = false;

            axios.get('/Division/Edit/' + id).then(response => {
                this.Division = {
                    id: response.data.id,
                    name: response.data.name,
                }

            });
        },
        Delete: function (name, id) {
            var r = confirm("Do You Want to Delete " + id + "-" + name + " ?");
            if (r === true) {
                axios.delete('/Division/Remove/' + id).then(response => {

                    this.GetAll();
                });

            }
        },



    },
    mounted() {
        this.GetAll();
    },
    computed: {
        filteredDivisionList: function () {
            var Vmdivision = this;
            return this.DivisionList.filter(function (data) {
                return data.name.toLowerCase().indexOf(Vmdivision.search.toLowerCase()) >= 0

            });
        }
    }
})
