let FeedbackView = new Vue({
    el: '#FeedbackView',
    data: {
        FeedbackIdView: document.getElementById('getId').innerText,
        AuditEmid: document.getElementById('AuditEmid').innerText,
        FeedbackViewList: [],
        Feedbacklist: [],
        ReAuditReply: {},
        timestamp: "",
        AReplyId: "",
        Aempid: "",
        ReplyMessage: "",
        isMassage: true,
        isHide: false,
        ClassStatus:""
    },
    methods: {

        AllFeedbacklist() {
            axios.get('/AuditDashboard/AllFeedbackViewList/' + this.FeedbackIdView).then(response => {
                this.FeedbackViewList = response.data;
                if (this.FeedbackViewList.statusPending=="2"&&this.FeedbackViewList.auditFeetbackPersonId != null) {
                    this.isHide = true;
                }
            })
        },
        ReplayAuditPost() {
            this.ReAuditReply.id = this.FeedbackViewList.id;
            this.ReAuditReply.reauditFeetbackDate = this.timestamp;
            this.ReAuditReply.statusSettled = String(this.ReAuditReply.statusSettled);
            axios({
                method: 'post',
                url: '/AuditDashboard/RereplayAudit',
                data: this.ReAuditReply
            }).then(response => {

                if (response.data == "statusSettled") {                
                    this.ReplyMessage = " Status Settled not Selected";
                    this.ClassStatus = ['alert-danger'];
                    setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "FeetbackPersonEmpId") {                 
                    this.ReplyMessage = " FeetbackPerson not Define";
                    this.ClassStatus = ['alert-danger'];
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "reauditFeetback") {
                    this.ReplyMessage = " Audit Reply Empty";
                    this.ClassStatus = ['alert-danger'];
                    setTimeout(() => this.isMassage = false, 2000)
                }

                if (response.data == "Success") {
                    this.isHide = false;
                    this.ReplyMessage = "Reply Success";
                    this.ClassStatus = ['alert-success'];
                    setTimeout(() => this.isMassage = false, 2000)
                }
                
                if (response.data == "NotFound") {
                    this.ReplyMessage = "Not Found Person";
                    this.ClassStatus = ['alert-danger']; -
                        setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "InValid") {
                    this.ReplyMessage = "InValid";
                    this.ClassStatus = ['alert-danger'];
                    setTimeout(() => this.isMassage = false, 2000)
                }
            })

        },
        getNow() {
            const today = new Date();
            const date = today.getDate() + '-' + (today.getMonth() + 1) + '-' + today.getFullYear();
            const time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
            const dateTime = date + ' ' + time;
            this.timestamp = dateTime;
        }
       
    },
    mounted() {
        this.ReAuditReply.reauditFeetbackPersonEmpId = this.AuditEmid;
        this.AllFeedbacklist(this.FeedbackIdView);
        this.getNow();
        //this.interval = setInterval(() => {
        //    this.AllnotificationList();
        //}, 100)
    },
    computed: {

    }
})