let objectionView = new Vue({
    el: '#objectionview',
    data: {
        ViewId2: document.getElementById('Getid2').innerText,
        viewlist:[],
    },
    methods: {
        view(Id) {

            Id = this.ViewId2;
            axios.get('/Objection/viewfilterdata/' + Id).then(response => {
                this.viewlist = response.data;
                console.log(this.viewlist);
            })

        },
    },
    mounted() {
        if (this.ViewId2 != "") {
            this.view(this.ViewId2);
        }
    },
    computed: {

    }
})