var loginuser = new Vue({
    el: '#loginuser',
    data: {
        isMassage: false,
        errorMassage: "",
        ClassStatus: "",
        loginVm: {},
    },
    methods: {

        login() {
            axios({
                method: 'post',
                url: '/Client/Login',
                data: this.loginVm
            }).then(response => {
                if (response.data == "useridnotfound") {
                    this.errorMassage = "UserId Not Found";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 3000)
                }
                if (response.data == "passwordError") {
                    this.errorMassage = "Password Error";
                    this.ClassStatus = ['alert-danger'];
                    this.isMassage = true;
                    setTimeout(() => this.isMassage = false, 3000)
                }
            })
        },
    },
    mounted() {

    },
    computed: {

    }
})
