let Upzila = new Vue({
    el: '#Upzila',
    data: {
        IsShow: true,
        isMassage: false,
        errorMassage: "",
        ClassStatus: "",
        search: "",
        Upzila: {},
        UpzilatList: [],

    },
    methods: {
        Create() {

            axios({
                method: 'post',
                url: '/Upzila/Create',
                data: this.Upzila
            }).then(response => {

                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)

                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The Upzila Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


                if (response.data == "2") {
                    this.errorMassage = "Upzila Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "Success") {
                    this.errorMassage = "Upzila Create Success ";
                    this.ClassStatus = ['alert-success'];
                    this.GetAll();
                    this.Upzila = {};
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


            })

        },

        Update() {

            axios({
                method: 'post',
                url: '/Upzila/Update',
                data: this.Upzila
            }).then(response => {


                if (response.data == "Failed") {
                    this.errorMassage = "Failed";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)

                }
                if (response.data == "1") {
                    this.errorMassage = "Enter The Upzila Name";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


                if (response.data == "2") {
                    this.errorMassage = "Upzila Already Exists ";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "Success") {
                    this.errorMassage = "Upzila Update Success ";
                    this.ClassStatus = ['alert-success'];
                    this.GetAll();
                    this.Upzila = {};
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 2000)
                }


            })

        },

        GetAll() {
            axios({
                method: 'get',
                url: '/Upzila/GetAll',
            }).then(response => {
                this.UpzilatList= response.data;
                //console.log(this.DivisionList);
            })
        },

        Edit(id) {
            this.IsShow = false;

            axios.get('/Upzila/Edit/' + id).then(response => {
                this.Upzila = {
                    id: response.data.id,
                    name: response.data.name,
                }

            });
        },
        Delete: function (name, id) {
            var r = confirm("Do You Want to Delete " + id + "-" + name + " ?");
            if (r === true) {
                axios.delete('/Upzila/Remove/' + id).then(response => {

                    this.GetAll();
                });

            }
        },



    },
    mounted() {
        this.GetAll();
    },
    computed: {
        filteredUpzilaList: function () {
            var Vmdivision = this;
            return this.UpzilatList.filter(function (data) {
                return data.name.toLowerCase().indexOf(Vmdivision.search.toLowerCase()) >= 0

            });
        }
    }
})
