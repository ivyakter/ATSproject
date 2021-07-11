let ProfileAudit = new Vue({
    el: '#Profile',
    data: {
        ProfileId: document.getElementById('profileId').innerText,
        Profilelist: [],
        AllfeedBackCountlist: [],
        countObjection: "",
        EditProfile: {}
    },
    methods: {
        profileView() {
            axios.get('/AuditDashboard/profileView/' + this.ProfileId).then(response => {
                this.Profilelist = response.data;
            })
        },

        AllfeedBackCount() {
            axios.get('/AuditDashboard/AllfeedBackCount/' + this.ProfileId).then(response => {
                this.AllfeedBackCountlist = response.data;
                this.countObjection = this.AllfeedBackCountlist.length;
                console.log(this.countObjection);
            })
        },
        eidtprofile(id) {
            axios.get('/AuditDashboard/Editprofile/' + id).then(response => {
                this.EditProfile = {
                    id:response.data.id,
                    name:response.data.name,
                    employeeId:response.data.employeeId,
                    dateofBirth:response.datadateofBirth,
                    firstDesignation:response.data.firstDesignation,
                    currentDesignation:response.data.currentDesignation,
                    email:response.data.email,
                    mobileNo:response.data.mobileNo,
                }

            });
        }
    },
    mounted() {
        this.profileView(this.ProfileId);
        this.AllfeedBackCount(this.ProfileId);
       
    },
    computed: {

    }
})