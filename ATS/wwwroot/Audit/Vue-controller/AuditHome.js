let AuditHome = new Vue({
    el: '#AuditHome',
    data: {
        auditId: document.getElementById('Auditname').innerText,
        AuditNotificatioList: [],
        datetime: "",
        Feedbacklist:[]
    },
    methods: {

        AllnotificationList() {
            axios.get('/AuditDashboard/demo/' + this.auditId).then(response => {           
                this.AuditNotificatioList = response.data;
                //console.log(response.data);
            })
        }, 

        replyAudit(id) {      
            window.location.href = "/AuditDashboard/Reply/" + id;
        },

        AllFeedbacklist() {
            axios.get('/AuditDashboard/AllFeedback/' + this.auditId).then(response => {
                this.Feedbacklist = response.data;
                
            })
        }, 

    },
    mounted() {

        this.AllnotificationList(this.auditId);
        this.AllFeedbacklist(this.auditId);


        //this.interval = setInterval(() => {
        //    this.AllnotificationList();
        //}, 100)
    },
    computed: {

    }
})