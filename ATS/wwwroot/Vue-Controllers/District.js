let District = new Vue({
    el: '#District',
    data: {
        IsShow: true,
        isMassage: false,
        errorMassage: "",
        ClassStatus: "",
        search: "",
        District: {},
        DistrictList: [],

    },
    methods: {
        Create() {

            axios({
                method: 'post',
                url: '/District/Create',
                data: this.District
            }).then(response => {

                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)

                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The District Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


                if (response.data == "2") {
                    this.errorMassage = "District Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "Success") {
                    this.errorMassage = "District Create Success ";
                    this.ClassStatus = ['alert-success'];
                    this.GetAll();
                    this.District = {};
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


            })

        },

        Update() {

            axios({
                method: 'post',
                url: '/District/Update',
                data: this.District
            }).then(response => {


                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)

                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The District Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


                if (response.data == "2") {
                    this.errorMassage = "District Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "Success") {
                    this.errorMassage = "District Update Success ";
                    this.ClassStatus = ['alert-success'];
                    this.GetAll();
                    this.District = {};
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


            })

        },

        GetAll() {
            axios({
                method: 'get',
                url: '/District/GetAll',
            }).then(response => {
                this.DistrictList = response.data;
                //console.log(this.DivisionList);
            })
        },

        Edit(id) {
            this.IsShow = false;

            axios.get('/District/Edit/' + id).then(response => {
                this.District = {
                    id: response.data.id,
                    name: response.data.name,
                }

            });
        },
        Delete: function (name, id) {
            var r = confirm("Do You Want to Delete " + id + "-" + name + " ?");
            if (r === true) {
                axios.delete('/District/Remove/' + id).then(response => {

                    this.GetAll();
                });

            }
        },



    },
    mounted() {
        this.GetAll();
    },
    computed: {
        filteredDistrictList: function () {
            var Vmdivision = this;
            return this.DistrictList.filter(function (data) {
                return data.name.toLowerCase().indexOf(Vmdivision.search.toLowerCase()) >= 0

            });
        }
    }
})
