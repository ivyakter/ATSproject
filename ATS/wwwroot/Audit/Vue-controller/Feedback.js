let Feedback = new Vue({
    el: '#Feedback',
    data: {
        FeedbackId: document.getElementById('Feedbackname').innerText,       
        Feedbacklist: [],
        search:""
    },
    methods: {

        AllFeedbacklist() {
            axios.get('/AuditDashboard/AllFeedbackList/' + this.FeedbackId).then(response => {
                this.Feedbacklist = response.data;
    
            })
        },
      
        ViewFeedback(id) {
            window.location.href = "/AuditDashboard/ViewFeedback/" + id;
        }
    },
    mounted() {
        this.AllFeedbacklist(this.FeedbackId);
       

        //this.interval = setInterval(() => {
        //    this.AllnotificationList();
        //}, 100)
    },
    computed: {
        filteredFeedbacklist: function () {
            var vm = this;
            return this.Feedbacklist.filter(function (item) {
                return item.mobileNo.toLowerCase().indexOf(vm.search.toLowerCase()) >= 0



            });
        }
    }
})