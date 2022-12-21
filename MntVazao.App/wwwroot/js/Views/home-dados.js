$(document).ready(function () {

    $(".campo-data").inputmask("99/99/9999");

    $('#iProcurarMedicaoLeitura').keyup(function () {
        $(this).val(this.value.replace(/[^\d,]/g, ''));
    });

    $.fn.DataTable.ext.pager.numbers_length = 5;
    $('#tblDados').DataTable({
        "processing": true,
        "serverSide": true,
        "aaSorting": [[1, "desc"]],
        ajax: {
            url: ("/Home/ListarDados"),
            type: "POST",
            datatype: "json",
            data: function (data) {
                data.sensorId = $("#iProcurarSensorId").val();
                data.medicaoDataInicio = $("#iProcurarMedicaoDataInicio").val();
                data.medicaoDataFim = $("#iProcurarMedicaoDataFim").val();
                data.medicaoLeitura = $("#iProcurarMedicaoLeitura").val();
                data.medicaoStatus = $("#iProcurarMedicaoStatus").val();
            }
        },
        columns: [
            {
                data: "sensor_ID",
                class: "text-nowrap text-center",
            },
            {
                data: "medicao_DataInicio",
                class: "text-nowrap text-center",
            },
            {
                data: "medicao_DataFim",
                class: "text-nowrap text-center",
            },
            {
                data: "medicao_Leitura",
                class: "text-nowrap text-center",
            },
            {
                data: "medicao_Status",
                class: "text-nowrap text-center",
            },
        ],



        "language": {
            "lengthMenu": "Apresentar _MENU_ linhas por página",
            "zeroRecords": "Não há registros",
            "search": "Pesquisar:",
            "emptyTable": "Sem dados disponíveis na tabela",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ registros",
            "infoEmpty": "Não há registros",
            "infoFiltered": "(Filtrando de _MAX_ registros)",
            "loadingRecords": "Carregando...",
            "processing": "Processando...",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior",
            },
            "decimal": ".",
            "thousands": ".",
            buttons: {
                copyTitle: 'Copiar para área de transferência',
                copySuccess: {
                    _: '%d linhas copiadas',
                    1: '1 linha copiada'
                }
            }
        },
        "lengthMenu": [[5, 10, 25, 50, 100, 1000, 3000, 5000], [5, 10, 25, 50, 100, 1000, 3000, 5000]],

        dom:
            "<'row'<'col-md-3'l><'col-md-9 d-flex justify-content-end'B>>" +
            "<'row'<'col-md-12'tr>>" +
            "<'row'<'col-md-5'i><'col-md-7'p>>",
        buttons: [
            {
                extend: 'copy',
                text: '<i class="fas fa-copy"></i>',
                titleAttr: 'Copiar página atual',
                className: 'btn btn-secondary btn-lg',
                exportOptions: {
                    modifier: {
                        page: 'current'
                    }
                }
            },
            {
                extend: 'excel',
                text: '<i class="fas fa-file-excel"></i>',
                titleAttr: 'Exportar para Excel',
                className: 'btn btn-success btn-lg',
                exportOptions: {
                    modifier: {
                        page: 'current'
                    },
                    format: {
                        body: function (data, row, column, node) {
                            data = $('<p>' + data + '</p>').text();
                            return $.isNumeric(data.replace(',', '.')) ? data.replace(',', '.') : data;
                        }
                    }
                }
            },
            {
                extend: 'pdf',
                text: '<i class="fas fa-file-pdf"></i>',
                titleAttr: 'Exportar para PDF',
                className: 'btn btn-danger btn-lg',
                exportOptions: {
                    modifier: {
                        page: 'current'
                    }
                }
            },
        ],
    });

    $("#btn-filtrar").click(function () {
        var table = $("#tblDados").DataTable();
        table.page(1);
        table.ajax.reload();
    });

    $.fn.datepicker.defaults.format = "dd/mm/yyyy";
    $.fn.datepicker.defaults.language = "pt-BR";

    $('.datepicker').datepicker({
        autoclose: true
    })
});
