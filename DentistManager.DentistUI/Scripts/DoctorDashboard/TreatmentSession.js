$('document').ready(function () {
    Main.Init();
});

var selector,
    Main = {
        selectors: {
            hidnAppointmentID: $('#AppointmentID'),
            hidnDoctorID: $('#DoctorID'),
            hidnPatientID: $('#PatientID'),
            TreatmentList: $('#TreatmentList'),
            appointmentDate: $('#appointmentDate').val(),
            btnRemoveTreatment: $('.btnRemoveTreatment'),
            btnSaveTreatments: $('#btnSaveTreatments'),
            treatmentItemID:1
        },
        Init: function () {

            selector = this.selectors;
            vm = this.vmTreatmentList;

            this.getTreatmentList();
            this.loadTreatmentList();
            this.loadGraphDraw();
            this.BindUiActions();
        },
        BindUiActions: function () {

            selector.btnSaveTreatments.on("click", function () {

                Main.saveTreatmentToObject();
                Main.saveTreatmentToDatabase();
            });

            $(document).on('click', '.btnRemoveTreatment', function () {
                // remove the treatment from the ui , database , array
                var s = $(this).parent().children('.TeratmentID').val();

                for (var i = 0; i < vm.length; i++) {
                    if (vm[i].TreatmentID === s) {
                        vm[i].remove();
                    }
                }

                Main.RemoveTreatmentItem(s);
                $(this).parent().remove();

                Main.loadGraphDraw();
            });



        },
        obTreatmentListItem: function (treatmentItemID,TeratmentID, Description, AppointmentDate, opperatioName, TeratmentCost, treatmentState, toothNumber, toothSideNumber, opperationColor) {
            this.treatmentItemID = treatmentItemID;
            this.TeratmentID = TeratmentID;
            this.Description = Description;
            this.AppointmentDate = AppointmentDate;
            this.opperatioName = opperatioName;
            this.TeratmentCost = TeratmentCost;
            this.treatmentState = treatmentState;
            this.toothNumber = toothNumber;
            this.toothSideNumber = toothSideNumber;
            this.opperationColor = opperationColor;
        },
        getTreatmentList: function () {
            var patientID = selector.hidnPatientID.val();
            $.ajax({
                url: "/DoctorDashboard/TreatmentSession/GetTreatmentListByPatientID",
                type: "post",
                dataType: "json",
                contentType: "application/json",
                cache: false,
                async: false,
                data: JSON.stringify({ patientID: patientID }),
                success: function (result) {
                    for (var i = 0; i < result.length; i++) {
                        selector.treatmentItemID = selector.treatmentItemID + 1;
                        vm.push(new Main.obTreatmentListItem(selector.treatmentItemID, result[i].TeratmentID, result[i].Description, result[i].AppointmentDate, result[i].opperatioName, result[i].TeratmentCost, result[i].treatmentState, result[i].toothNumber, result[i].toothSideNumber, result[i].opperationColor));
                    }
                }
            });

        },
        RemoveTreatmentItem: function (TreatmentID) {
            $.ajax({
                url: "/DoctorDashboard/TreatmentSession/RemoveTreatmentItem",
                type: "post",
                dataType: "json",
                contentType: "application/json",
                cache: false,
                async: false,
                data: JSON.stringify({ treatmentID: TreatmentID }),
                success: function () {
                    alert('Treatment Has Been Removed');
                }
            });
        },
        loadTreatmentList: function () {
            for (var i = 0; i < vm.length; i++) {
                $('#TreatmentList').append('<li> <input class="treatmentItemID" type="hidden" value="' + Main.vmTreatmentList[i].treatmentItemID + '" /> <input class="TeratmentID" type="hidden" value="' + Main.vmTreatmentList[i].TeratmentID + '" /> <label id="toothSideNumber" > ' + Main.vmTreatmentList[i].toothSideNumber + '</label> <label id="toothNumber" > ' + Main.vmTreatmentList[i].toothNumber + '</label>   <label id="opperatioName" > ' + Main.vmTreatmentList[i].opperatioName + '</label>  <label id="AppointmentDate" > ' + Main.vmTreatmentList[i].AppointmentDate + '</label> <input class="Description" type="text" value="' + Main.vmTreatmentList[i].Description + '" />   <input class="TeratmentCost" type="text" value="' + Main.vmTreatmentList[i].TeratmentCost + '" /> <input type="button" class="btnRemoveTreatment" value="X" /> </li>');
            }
        },
        saveTreatmentToObject:function(){
            $('#TreatmentListWrap ul li').each(function () {
                var s = $(this).children('.treatmentItemID').val();
                var description = $(this).children('.Description').val();
                var treatmentCost = $(this).children('.TeratmentCost').val();

                for (var i = 0; i < vm.length; i++) {
                    if (vm[i].treatmentItemID == s) {
                        vm[i].Description = description;
                        vm[i].TeratmentCost = treatmentCost;
                    }
                }
            });
        },
        saveTreatmentToDatabase: function () {
            $.ajax({
                url: "/DoctorDashboard/TreatmentSession/TreatmentSave",
                type: "post",
                dataType: "json",
                contentType: "application/json",
                cache: false,
                async: false,
                data: JSON.stringify({ treatmentList: vm }),
                success: function () {
                    alert('Treatments Has Been Saved');
                }
            });
        },
        loadGraphDraw: function () {

            stage = new Kinetic.Stage({
                container: 'container',
                width: 1200,
                height: 500
            });
            layer = new Kinetic.Layer();

            drawCircle = function (X, Y, Radius, FillColor, StrokeColor, StrokeWidth, ID) {
                var circle = new Kinetic.Circle({
                    x: X,
                    y: Y,
                    radius: Radius,
                    fill: FillColor,
                    stroke: StrokeColor,
                    strokeWidth: StrokeWidth,
                    id: ID
                });
                return circle;
            }
            drawWadg = function (X, Y, Radius, Angle, FillColor, StrokeColor, StrokeWidth, Rotation, ID) {
                var wedge = new Kinetic.Wedge({
                    x: X,
                    y: Y,
                    radius: Radius,
                    angle: Angle,
                    fill: FillColor,
                    stroke: StrokeColor,
                    strokeWidth: StrokeWidth,
                    rotation: Rotation,
                    id: ID
                });
                return wedge;
            }
            drawText = function (X, Y, Text, FontSize, FontFamily, FillColor) {
                var myText = new Kinetic.Text({
                    x: X,
                    y: Y,
                    text: Text,
                    fontSize: FontSize,
                    fontFamily: FontFamily,
                    fill: FillColor
                })
                return myText;
            }

            var xPosation = 100;
            var yPosation = 100;

            var wedge1color1;
            var wedge1color2;
            var wedge1color3;
            var wedge1color4;
            var wedge1color5;
            var count = 0;

           
            
            for (var i = 1; i < 33; i++) {

                wedge1color1 = '#ffffff';
                wedge1color2 = '#ffffff';
                wedge1color3 = '#ffffff';
                wedge1color4 = '#ffffff';
                wedge1color5 = '#ffffff';

                if (count < vm.length) {
                    for (var k = 0; k < vm.length; k++) {
                        if (vm[k].toothNumber === i) {
                            if (vm[k].toothSideNumber === 1)
                                wedge1color1 = vm[k].opperationColor;
                            else if (vm[k].toothSideNumber === 2)
                                wedge1color2 = vm[k].opperationColor;
                            else if (vm[k].toothSideNumber === 3)
                                wedge1color3 = vm[k].opperationColor;
                            else if (vm[k].toothSideNumber === 4)
                                wedge1color4 = vm[k].opperationColor;
                            else if (vm[k].toothSideNumber === 5)
                                wedge1color5 = vm[k].opperationColor;
                            count++;
                        }
                    }
                }

                var wedge1 = drawWadg(xPosation, yPosation, 30, 90, wedge1color1, 'black', 2, 225, i + "-1");
                var wedge2 = drawWadg(xPosation, yPosation, 30, 90, wedge1color2, 'black', 2, 315, i + "-2");
                var wedge3 = drawWadg(xPosation, yPosation, 30, 90, wedge1color3, 'black', 2, 45, i + "-3");
                var wedge4 = drawWadg(xPosation, yPosation, 30, 90, wedge1color4, 'black', 2, 135, i + "-4");
                var circle1 = drawCircle(xPosation, yPosation, 12, wedge1color5, 'black', 2, i + "-5");
                var text1 = drawText(xPosation - 5, yPosation + 40, i, 14, 'arial', 'black');

                wedge1.on("click", Main.clickEventMsg)
                wedge2.on("click", Main.clickEventMsg);
                wedge3.on("click", Main.clickEventMsg);
                wedge4.on("click", Main.clickEventMsg);
                circle1.on("click", Main.clickEventMsg);


                layer.add(wedge1);
                layer.add(wedge2);
                layer.add(wedge3);
                layer.add(wedge4);
                layer.add(circle1);
                layer.add(text1);

                xPosation += 65;

                if (i == 16) {
                    yPosation += 100;
                    xPosation = 100;
                }
            }
            stage.add(layer);
        },
        clickEventMsg: function () {
            var selectedValue = $('input[name=SelectedOpperation]:radio:checked', '#OpperationForm').val();
            if (typeof selectedValue === 'undefined') {
                alert('Please Select Opperation');
                return;
            }

            var oppName = $('input[name=SelectedOpperation]:radio:checked', '#OpperationForm').data('opperationname');
            var oppColor = $('input[name=SelectedOpperation]:radio:checked', '#OpperationForm').data('fillcolor');
            var index = this.attrs.id.indexOf('-');
            var toothNumber = this.attrs.id.substr(0, index);
            var toothSideNumber = this.attrs.id.substr(index + 1, this.attrs.id.length - 1);

            selector.treatmentItemID = selector.treatmentItemID + 1;

            vm.push(new Main.obTreatmentListItem(selector.treatmentItemID,0, '', selector.appointmentDate, oppName, '', 'State : in progress', toothNumber, toothSideNumber, oppColor));

            $('#TreatmentList').append('<li> <input class="treatmentItemID" type="hidden" value="' + selector.treatmentItemID + '" /> <input class="TeratmentID" type="hidden" value="' + 0 + '" /> <label id="toothSideNumber" > ' + toothSideNumber + '</label> <label id="toothNumber" > ' + toothNumber + '</label>   <label id="opperatioName" > ' + oppName + '</label>  <label id="AppointmentDate" > ' + selector.appointmentDate + '</label> <input class="Description" type="text" value="" />   <input class="TeratmentCost" type="text" value="" /> <input type="button" class="btnRemoveTreatment" value="X" /> </li>');

            Main.loadGraphDraw();
            alert('test');

        },
        vmTreatmentList: []
    };


