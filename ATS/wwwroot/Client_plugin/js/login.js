var gg = new Vue({
    el: "#login",
    data: {
     
  categoty: [
    { id: 1, name: "FAPAD" },
    { id: 2, name: "LAD" },
    { id: 3, name: "Internal" },
  ],
  
  
  mainProjectList: [
    { id: 1, name: "HPNSP" },
    { id: 2, name: "FPSD" },
    { id: 3, name: "USAID" },
    { id: 4, name: "BSAID" },
    { id: 5, name: "FP Main Scheem " },
  ],
  yearsList: [
    { id: 1, name: "2020" },
    { id: 2, name: "2019" },
    { id: 3, name: "2018" },
    { id: 4, name: "2017" },
    { id: 5, name: "2016" },
  ],
  EmpList: [
    {
      id: 1,
      employeeId: "ATS0001",
      name: "Ahammed Ali",
      designation:"Divisional officer",
      posting:"Savar Upazila",
      years:"2020",
      amount: "25,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.25,99,00,000.00 procurement",
      date: "2020-07-10",
      division: "Dhaka",
      district: "Dhaka",
      upazila: "Mohamoddpur Upazila",
      projectId: 1,
      projectname:"HPNSP",
      categotyId: 1,
      categotyname:"FAPAD",
      status: 1,
      password:"ATS0001",
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
    },
  {
      id: 2,
      employeeId:"ATS0002",
      password:"ATS0002",
      name: "Shakil KHAN",
      designation:"Divisional officer",
  posting:"Savar Upazila",
  years:"2020",
      amount: "20,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.30,99,00,000.00 procurement",
      years: 2020,
      date: "2019-17-10",
      division: "Dhaka",
      district: "Dhaka",
      upazila: "Savar Upazila",
      projectId: 2,
      projectname:"FPSD",
      categotyId: 1,
      categotyname:"FAPAD",
      status: 2,
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
    },
  
  {
  id: 3,
      employeeId:"ATS0003",
      name: "Zubayer Parvez",
      designation:"Divisional officer",
  posting:"Dhaka",
  years:"2017",
      amount: "15,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.20,99,00,000.00 procurement",
      years: 2018,
      date: "2018-17-10",
      division: "Khulna",
      district: "Meherpur",
      upazila: "Meherpur Upazila",
      projectId: 3,
      projectname:"USAID",
      categotyId: 1,
      categotyname:"FAPAD",
      password:"ATS0003",
      status: 3,
      password:"ATS0003",
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 4,
      employeeId:"ATS0004",
      name: "Joy Molla",
      designation:"District officer",
  posting:"Kushtia Upazila",
  years:"2020",
      amount: "40,90,00,000.00",
      titel:"Irregular expenditure amounting to TK.40,90,00,000.00 procurement",
    
      date: "2018-15-12",
      division: "Dhaka",
      district: "Madaripur",
      upazila: "Madaripur Upazila",
      projectId: 4,
      projectname:"BSAID",
      categotyId: 2,
      categotyname:"LAD",
      status: 2,
      password:"ATS0004",
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 5,
  employeeId:"ATS0005",
      name: "Sobuj Ali",
      designation:"Divisional officer",
  posting:"Savar Upazila",
  years:"2016",
      amount: "10,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.10,99,00,000.00 procurement",
      years: 2018,
      date: "2018-17-10",
      division: "Barishal",
      district: "Bhola",
      upazila: "Bhola Upazila",
      projectId: 1,
      projectname:"HPNSP",
      categotyId: 2,
      categotyname:"LAD",
      status: 1,
      password:"ATS0005",
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 6,
      employeeId:"ATS0006",
      name: "Jisan Khan",
      designation:"Divisional officer",
  posting:"Chadpur Upazila",
  years:"2017",
      amount: "50,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.50,99,00,000.00 procurement",
      years: 2018,
      date: "2018-10-12",
      division: "Chittagong",
      district: "Chadpur",
      upazila: "Chadpur Upazila",
      projectId: 1,
      projectname:"HPNSP",
      categotyId: 3,
      categotyname:"Internal",
      status: 2,
      password:"ATS0006",
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 7,
      employeeId:"ATS0007",
      name: "Alve Ahamed",
      designation:"DD",
  posting:"Panba Upazila",
  years:"2018",
      amount: "40,99,00,000.00",
      titel:"Irregular expenditure amounting to TK.40,99,00,000.00 procurement",
      years: 2018,
      date: "2018-10-08",
      division: "Chittagong",
      district: "Chadpur",
      upazila: "Chadpur Upazila",
      projectId: 4,
      projectname:"BSAID",
      categotyId: 2,
      categotyname:"LAD",
      status: 3,
      password:"ATS0007",
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 8,
      employeeId:"ATS0008",
      name: "Polok Ahamed",
      designation:"DD",
  posting:"Monshiganj",
  years:"2019",
      amount: "10,90,00,000.00",
      titel:"Irregular expenditure amounting to TK.10,99,00,000.00 procurement",
      years: 2019,
      date: "2019-10-10",
      division: "Dhaka",
      district: "Monshiganj",
      upazila: "Monshiganj Upazila",
      projectId: 5,
      projectname:"fP Main Scheem",
      categotyId: 3,
      categotyname:"Internal",
      status: 2,
      password:"ATS0008",
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 9,
      employeeId:"ATS0009",
      name: "Rabbani Ahamed",
      designation:"DG",
  posting:"Dhaka",
  years:"2017",
      amount: "20,90,00,000.00",
      titel:"Irregular expenditure amounting to TK.20,99,00,000.00 procurement",
      years: 2019,
      date: "2019-10-10",
      division: "Dhaka",
      district: "Dhaka",
      upazila: "Narayanganj Upazila",
      projectId: 3,
      projectname:"USAID",
      categotyId: 3,
      categotyname:"fAPAD",
      status: 1,
      password:"ATS0009",
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  
  {
  id: 10,
      employeeId:"ATS0010",
      name: "Shofiq Ahamed",
      designation:"DD",
      posting:"Dhaka",
      years:"2017",
      amount: "20,90,00,000.00",
      titel:"Irregular expenditure amounting to TK.20,99,00,000.00 procurement",
      years: 2018,
      date: "2018-10-10",
      division: "Dhaka",
      district: "Dhaka",
      upazila: "Saver Upazila",
      projectId: 3,
      projectname:"FPSD",
      categotyId: 3,
      categotyname:"fAPAD",
      status: 1,
      password:"ATS0010",
      description:"Audit was conducted on the accounts of the 'Clinical Contraception Service Delivery Program under HPNSDP financed by IDA in the office of the Director, Logistics & Supply (L & S), Karwanbazar, Dhaka, DGFP for the Financial year 2014-2015.",
  },
  ],

      logindata:{},
      pas:"",
      empid:"",
      showsalert:false,
      showsalert1:false,
      emppassword:{},
      passid:"",
      emplistid:"",
      emplistpass:"",
    },
  
    methods: {
      login(){
       
          if(this.logindata.employeeId ==undefined ||this.logindata.employeeId =="" && this.logindata.password ==undefined ||this.logindata.password ==""){
            this.showsalert1=true;
            setTimeout(() => (this.showsalert1 = false), 3000);
           
          }    
          else
          {
            this.validnull();
          }
        },

          validnull(){
            if(this.logindata.employeeId !==undefined  && this.logindata.employeeId !==undefined ){
                this.empid=this.logindata.employeeId;
                this.pas=this.logindata.password;        
                this.emppassword=this.EmpList.find((k) => k.employeeId ===this.empid &&k.password===this.pas);
                this.herfvalid();
            }
                else{
                    this.showsalert=true;
                setTimeout(() => (this.showsalert = false), 3000);
                this.logindata.employeeId ="";
                this.logindata.password="";               
              }
    
              
              
            },
          
      
      herfvalid(){
                          
        if(this.emppassword !==undefined){
            if(this.empid===this.emppassword.employeeId&& this.pas=== this.emppassword.password){
                window.location.href = "viewcase.html?id=" + this.emppassword.id;
             }
        }
        else{
            this.showsalert=true;
        setTimeout(() => (this.showsalert = false), 3000);
        this.logindata.employeeId ="";
        this.logindata.password="";               
      }

      }
    },
  });
  