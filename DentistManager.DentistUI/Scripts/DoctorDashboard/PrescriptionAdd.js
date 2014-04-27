$('document').ready(function () {
    Main.Init();
});


var selector,
    Main = {
        selectors: {
            btnAdd: $('#btnAdd'),
            btnSavePresc: $('#btnSavePresc'),
        },
        Init: function () {

            selector = this.selectors;
            vm = this.vmPrescription;

            this.BindUiActions();
        },
        BindUiActions: function () {
            selector.btnAdd.on("click", function () {
                var _medID = $("#MedicineDropDown option:selected").val();
                var _medName = $("#MedicineDropDown option:selected").text();
                                
               var _doseVal = $("#MedicineDropDown option:selected").data('dose');
               var _ScaleType = $("#MedicineDropDown option:selected").data('scaletype');
               var _Concentration = $("#MedicineDropDown option:selected").data('concentration');
               //var _SideEffectDecsription = $("#MedicineDropDown option:selected").data('sideeffectdecsription');

               var innerIL = '<tr> <td><input class="medicenID" type="hidden" value="' + _medID + '" />  <label class="medicenName" > ' + _medName + '</label>  </td><td><label class="_txtDose" > ' + _doseVal + '</label> </td><td>  <label class="_txtUnite" > ' + _ScaleType + '</label>  </td>  <td><label class="_txtFocuse" > ' + _Concentration + '</label>  </td> <td> <input type="button" class="btnRemoveMedcFromList" value="X" /></td> </tr>';

                $(this).parent().parent().parent().find('tr:last').after(innerIL);

                vm.push(new Main.obPrescriptionMedicine(_medID));
               
            });
            $(document).on('click', '.btnRemoveMedcFromList', function () {
                $(this).parent().parent().remove();
            });
            selector.btnSavePresc.on("click", function () {

               
                $.ajax({
                    url: "/DoctorDashboard/Prescription/SavePrescraptionMedcList",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json",
                    cache: false,
                    async: false,
                    data: JSON.stringify({ medList: vm }),
                    success: function (result) { window.location = result.RedirectUrl; }
                });

            });
        },
        obPrescriptionMedicine: function (MedicineID) {     
            this.MedicineID = MedicineID;
            //this.Dose = Dose;      , Dose, ScaleType, Foucse       
            //this.ScaleType = ScaleType;
            //this.Foucse = Foucse;
        },
        vmPrescription: []
    }

//obPrescription: function (Notice, MedicineID, PatientID, DoctorID, Dose, AppointmentID, Medicines) {
//    this.Notice = Notice;
//    this.MedicineID = MedicineID;
//    this.PatientID = PatientID;
//    this.DoctorID = DoctorID;
//    this.Dose = Dose;
//    this.AppointmentID = AppointmentID;
//    this.Medicines = Medicines;
//},
//obMedicine: function (MedicineID, Name, SideEffectDecsription, ScaleType) {
//    this.MedicineID =MedicineID;
//    this.Name = Name;
//    this.SideEffectDecsription = SideEffectDecsription;
//    this.ScaleType = ScaleType;
//},