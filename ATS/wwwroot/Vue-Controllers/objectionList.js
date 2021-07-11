let objection = new Vue({
    el: '#objectionlist',
    data: {

        ObjectionList: [],
    },
    methods: {


        //GetAll() {
        //    axios({
        //        method: 'get',
        //        url: '/Objection/get',
        //    }).then(response => {
        //        this.ObjectionList = response.data;
        //        console.log(this.ObjectionList);
        //    })
        //},
        
        Edit(id) {
            window.location.href = "/Objection/Edit/" + id;
        },
        view(id) {
            window.location.href = "/Objection/Viewdata/" + id;
        }


    },
    mounted() {
        //this.GetAll();
    },


})