let AuditLayout = new Vue({
    el: '#AuditLayout',
    data: {
        getauditId: document.getElementById('AuditnameId').innerText,
        AuditDashboardListsaidbar: [],
        Allsubmitionlist: [],
        CategoryNamelist:[],
        AllFeedbacklist:[],
        notification: "",
        Allsubmitioncount: "",
        AllFeedbackCount: "",
        ErrorMeassOne: "",
        ErrorMeassTwo:"",
    },
    methods: {

        AllnotificationListsidbar() {
            axios.get('/AuditDashboard/notificationsaidbar/' + this.getauditId).then(response => {
                this.Allsubmitionlist = response.data;
                this.notification = this.Allsubmitionlist.length;  
            })
        }, 
       
        //Allsubmition() {
        //    axios.get('/AuditDashboard/Allsubmissiongetdata/' + this.getauditId).then(response => {
        //        this.AuditDashboardListsaidbar = response.data;
        //        this.Allsubmitioncount = this.AuditDashboardListsaidbar.length;
        //    })
        //}, 


        AllFeedback() {
            axios.get('/AuditDashboard/AllFeedback/' + this.getauditId).then(response => {
                this.AllFeedbacklist = response.data;
                this.AllFeedbackCount = this.AllFeedbacklist.length;
            })
        }, 

        CategoryName() {
            axios.get('/AuditDashboard/CategoryName/' + this.getauditId).then(response => {             
                if (response.data == null) {      
                    this.ErrorMeassOne = "Empty Department";
                    this.ErrorMeassTwo = "Empty Audit";
                
                }
                if (response.data != null) {
                    this.CategoryNamelist = response.data;
                }
            
                
            })
        }, 
    },
    mounted() {
        //this.Allsubmition(this.getauditId);
        this.AllFeedback(this.getauditId);
        this.AllnotificationListsidbar(this.getauditId);
        this.CategoryName(this.getauditId);

        this.interval = setInterval(() => {
            if (this.Allsubmitionlist != null || this.AllFeedbacklist != null) {
                this.AllnotificationListsidbar();
                //this.Allsubmition();
                this.AllFeedback();
            }
        }, 100)
    },
    computed: {

    }
})