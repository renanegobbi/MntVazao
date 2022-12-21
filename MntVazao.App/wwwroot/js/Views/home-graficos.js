var Graficos = function () {
    var _exibirGrafico = function (dataConsultada = null, tipoVazao = null) {

        $.ajax({
            url: ("/Home/ListarGraficos"),
            type: "POST",
            datatype: "json",
            data: { "data": dataConsultada, "tipoVazao": tipoVazao },
            beforeSend: function () {
                $("#loader").show();
            },
            complete: function () {
                $("#loader").hide();
            },
            success: function (data) {
                var retorno = data;
                var horas = [];
                var litros = [];
                retorno.forEach(function (elemento, indice) {
                    horas[indice] = elemento.Key;
                    litros[indice] = elemento.Value;
                });

                var labelEixoX = (tipoVazao == null || tipoVazao == "0") ? "Hora" : "Dia";
                var ctx = $('#chart');

                if (window.myCharts != undefined)
                    window.myCharts.destroy();
                window.myCharts = new Chart(ctx, {
                    type: 'line',
                    data: {
                        labels: horas,
                        datasets: [
                            {
                                label: 'gráfico de barras',
                                type: 'bar',
                                data: litros,
                                backgroundColor:
                                    'rgba(54, 162, 235, 0.2)',
                                borderColor:
                                    'rgba(54, 162, 235, 1)',
                                borderWidth: 1

                            },
                            {
                                label: 'gráfico de linhas',
                                data: litros,
                                backgroundColor: [
                                    'rgba(54, 162, 235, 0.2)'
                                ],
                                borderColor: [
                                    'rgba(54, 162, 235, 1)'
                                ],
                                borderWidth: 1
                            }

                        ]
                    },
                    options: {
                        responsive: true,
                        maintainAspectRatio: true,
                        legend: {
                            display: true,
                            labels: {
                                fontSize: 15,
                            }
                        },
                        scales: {
                            x: {
                                display: true,
                                title: {
                                    display: true,
                                    text: 'Month',
                                    color: '#911',
                                    font: {
                                        family: 'Comic Sans MS',
                                        size: 20,
                                        weight: 'bold',
                                        lineHeight: 1.2,
                                    },
                                    padding: { top: 20, left: 0, right: 0, bottom: 0 }
                                }
                            },
                            y: {
                                display: true,
                                title: {
                                    display: true,
                                    text: 'Value',
                                    color: '#191',
                                    font: {
                                        family: 'Times',
                                        size: 20,
                                        style: 'normal',
                                        lineHeight: 1.2
                                    },
                                    padding: { top: 30, left: 0, right: 0, bottom: 0 }
                                }
                            },
                            xAxes: [{
                                ticks: {
                                    beginAtZero: true,
                                    fontSize: 15
                                },
                                scaleLabel: {
                                    display: true,
                                    labelString: labelEixoX,
                                    fontSize: 18
                                }
                            }],
                            yAxes: [{
                                ticks: {
                                    beginAtZero: true,
                                    fontSize: 15
                                },
                                scaleLabel: {
                                    display: true,
                                    labelString: "Litros",
                                    fontSize: 18
                                }
                            }],

                        }
                    }
                });
            },
        })
    };

    return {
        init: function () {

            _exibirGrafico();

            $.fn.datepicker.defaults.language = "pt-BR";

            FormatoDatapicker("99/99/9999", "dd/mm/yyyy", 0, 0);

            $("#iVazao").change(function () {
                var FormatoVazao = $(this).val();
                $("#iData").val("");
                // Vazao = Litros por Dia
                if (FormatoVazao == 1) {
                    FormatoDatapicker("99/9999", "mm/yyyy", "months", "months");
                }
                // Vazao = Litros por Hora
                if (FormatoVazao == 0) {
                    FormatoDatapicker("99/99/9999", "dd/mm/yyyy", 0, 0);
                }
            })

            $('.datepicker').datepicker({
                autoclose: true
            })

            $("#btn-buscar").click(function () {
                var tipoVazao = $("#iVazao").val();
                var data = $("#iData").val();
                _exibirGrafico(data, tipoVazao);
            });

            $("#btn-save-png").click(function () {
                $("#chart").get(0).toBlob(function (blob) {
                    saveAs(blob, "chart_mntvazao.png")
                });
            });
        }
    };
}();

$(document).ready(function () {
    Graficos.init();
});

function FormatoDatapicker(ParamInputmask, ParamFormat, ParamViewMode, ParamMinViewMode) {
    $("#iData").datepicker("destroy");
    $("#iData").inputmask(ParamInputmask);
    $("#iData").datepicker({
        format: ParamFormat,
        viewMode: ParamViewMode,
        minViewMode: ParamMinViewMode,
        orientation: "bottom right"
    }).on('changeDate', function (e) {
        $(this).datepicker('hide');
    });
}
