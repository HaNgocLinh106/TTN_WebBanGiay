var GioHang = {
    init: function () {
        GioHang.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/Home/AllSanPham";
        });

        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });

        $('#btnUpdate').off('click').on('click', function () {
            var listGiay = $('.form-control text-center');
            var GioHangList = [];
            $.each(listGiay, function (i, item) {
                GioHangList.push({
                    SoLuong: $(item).val(),
                    Giay: {
                        MaGiay: $(item).data('id')
                    }
                });          
            });
            $.ajax({
                url: '/GioHang/CapNhat',
                data: { GioHangModel: JSON.stringify(GioHangList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        $('#btnDeleteAll').off('click').on('click', function () {
           
            $.ajax({
                url: '/GioHang/XoaAll',              
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });


        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();

            $.ajax({
                data: {id:$(this).data('id')},
                url: '/GioHang/Xoa',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
    }
}
GioHang.init();