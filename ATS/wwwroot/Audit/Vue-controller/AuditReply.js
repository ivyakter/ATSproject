let AuditReply = new Vue({
    el: '#AuditReply',
    data: {
        AuditId: document.getElementById('AuditId').innerText,
        AuditEmid: document.getElementById('AuditEmid').innerText,
        AuditfillterbyList: [],
        AuditReply: {},
        timestamp: "",
        AReplyId: "",
        Aempid: "",
        ReplyMessage: "",
        isMassage: true,
        isHide: true,
        ClassStatus: ""
    },
    methods: {
        fillterbyauditdata(id) {          
            axios.get('/AuditDashboard/fillterbyauditdata/' + id).then(response => {
                this.AuditfillterbyList = response.data;
                this.AReplyId =this.AuditfillterbyList.id;
                this.Aempid = this.AuditfillterbyList.employeeId;
             
             
            })
        },
        ReplayAuditPost() {
            this.AuditReply.id = this.AReplyId;
            this.AuditReply.auditFeetbackDate = this.timestamp;
            this.AuditReply.statusPending = String(this.AuditReply.statusPending);
            this.AuditReply.statusSettled = String(this.AuditReply.statusSettled);           
            axios({
                method: 'post',
                url: '/AuditDashboard/ReplayAudit',
                data: this.AuditReply
            }).then(response => {
                if (response.data == "FeetbackPersonEmpId") {
                    this.ReplyMessage = " Feetback Person not Define";
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
                    setTimeout(() => window.location.href = "/AuditDashboard/Feedback", 2000)
                    
                    
                }
                if (response.data == "NotFound") {
                    this.ReplyMessage = "Not Found Person";
                    this.ClassStatus = ['alert-danger'];-
                    setTimeout(() => this.isMassage = false, 2000)
                }
                if (response.data == "InValid") {
                    this.ReplyMessage = "InValid";
                    this.ClassStatus = ['alert-danger'];
                    setTimeout(() => this.isMassage = false, 2000)
                }
            })

        },
        getNow(){
            const today = new Date();
            const date = today.getDate() + '-' + (today.getMonth() + 1) + '-' + today.getFullYear();
            const time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
            const dateTime = date + ' ' + time;
            this.timestamp = dateTime;           
        }

    },
    mounted() {
        this.AuditReply.auditFeetbackPersonEmpId = this.AuditEmid;
        this.getNow();
        if (this.ViewId1 != "") {
            this.fillterbyauditdata(this.AuditId);
        }
    },
    computed: {

    }
})