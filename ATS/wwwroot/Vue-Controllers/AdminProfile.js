let AdminProfile = new Vue({
    el: '#AdminProfile',
    data: {
        ViewId1: document.getElementById('getidname').innerText,
        editprofile: {},
        AdminprofileList: {},
        collection: "",
        isMassage: false,
        errorMassage: "",
        ClassStatus: "",
    },
    methods: {
        GetAdminData() {
            axios.get('/Dashboard/AdminprofileUpdate/' + this.ViewId1).then(response => {
                this.editprofile = {
                    id: response.data.id,
                    workplace: response.data.workplace,
                    firstDesignation: response.data.firstDesignation,
                    currentDesignation: response.data.currentDesignation,
                   }
                this.collection = this.editprofile.id;
                console.log(this.editprofile);
            });
        },
        AdminPersonalInformation() {
            axios.get('/Dashboard/GetAdminPersonalInformation/' + this.ViewId1).then(response => {
                this.AdminprofileList = response.data;
                })      
        },
        userprofileUpte() {
            this.editprofile.id = this.collection;
            axios({
                method: 'post',
                url: '/Dashboard/UpdateProfile',
                data: this.editprofile
            }).then(response => {
                if (response.data == "Success") {
                    this.isMassage = true;
                    this.errorMassage = "Update Success";
                    this.ClassStatus = ['alert-success'];
                    setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "NotFound") {
                    this.isMassage = true;
                    this.errorMassage = "Not Found User";
                    this.ClassStatus = ['alert-danger']; -
                        setTimeout(() => this.isMassage = false, 2000)
                }
            })
        }
    },
    mounted() {
        this.GetAdminData(this.ViewId1);
        this.AdminPersonalInformation(this.ViewId1);
    },
    computed: {

    }
})