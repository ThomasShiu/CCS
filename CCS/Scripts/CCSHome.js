// 樹狀選單
$(function () {

    var o = {
        showcheck: false,
        url: "/Home/GetTree",
        onnodeclick: function (item) {
            var tabTitle = item.text;
            var url = "../../" + item.value;
            var icon = item.Icon;
            if (!item.hasChildren) {
                addTab(tabTitle, url, icon);
            } else {

                $(this).parent().find("img").trigger("click");
            }
        }
    }
    $.post("/Home/GetTree", { "id": "0" },
        function (data) {
            if (data == "0") {
                window.location = "/Account";
            }
            o.data = data;
            $("#RightTree").treeview(o);
        }, "json");
});

      $(function () {
          $('#tab_menu-tabrefresh').click(function () {
              /* 重新設置該標籤 */
              var url = $(".tabs-panels .panel").eq($('.tabs-selected').index()).find("iframe").attr("src");
              $(".tabs-panels .panel").eq($('.tabs-selected').index()).find("iframe").attr("src", url);
          });
          // 在新窗口打開該標籤
          $('#tab_menu-openFrame').click(function () {
              var url = $(".tabs-panels .panel").eq($('.tabs-selected').index()).find("iframe").attr("src");
              window.open(url);
          });
          // 關閉當前
          $('#tab_menu-tabclose').click(function () {
              var currtab_title = $('.tabs-selected .tabs-inner span').text();
              $('#mainTab').tabs('close', currtab_title);
              if ($(".tabs li").length == 0) {
                  //open menu
                  $(".layout-button-right").trigger("click");
              }
          });
          // 全部關閉
          $('#tab_menu-tabcloseall').click(function () {
              $('.tabs-inner span').each(function (i, n) {
                  if ($(this).parent().next().is('.tabs-close')) {
                      var t = $(n).text();
                      $('#mainTab').tabs('close', t);
                  }
              });
              //open menu
              $(".layout-button-right").trigger("click");
          });
          // 關閉除當前之外的TAB 
          $('#tab_menu-tabcloseother').click(function () {
              var currtab_title = $('.tabs-selected .tabs-inner span').text();
              $('.tabs-inner span').each(function (i, n) {
                  if ($(this).parent().next().is('.tabs-close')) {
                      var t = $(n).text();
                      if (t != currtab_title)
                          $('#mainTab').tabs('close', t);
                  }
              });
          });
          // 關閉當前右側的TAB
          $('#tab_menu-tabcloseright').click(function () {
              var nextall = $('.tabs-selected').nextAll();
              if (nextall.length == 0) {
                  $.messager.alert('提示', '前面没有了!', 'warning');
                  return false;
              }
              nextall.each(function (i, n) {
                  if ($('a.tabs-close', $(n)).length > 0) {
                      var t = $('a:eq(0) span', $(n)).text();
                      $('#mainTab').tabs('close', t);
                  }
              });
              return false;
          });
          // 關閉當前左側的TAB 
          $('#tab_menu-tabcloseleft').click(function () {

              var prevall = $('.tabs-selected').prevAll();
              if (prevall.length == 0) {
                  $.messager.alert('提示', '后面没有了!', 'warning');
                  return false;
              }
              prevall.each(function (i, n) {
                  if ($('a.tabs-close', $(n)).length > 0) {
                      var t = $('a:eq(0) span', $(n)).text();
                      $('#mainTab').tabs('close', t);
                  }
              });
              return false;
          });

      });
$(function () {
    /* 為TAB綁定右鍵 */
    $(document).on('contextmenu', '.tabs li', function (e) {
        /* 選中當前處發事件的TAB */
        var subtitle = $(this).text();
        $('#mainTab').tabs('select', subtitle);
        // 顯示快捷菜單
        $('#tab_menu').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        return false;
    })
});




function addTab(subtitle, url, icon) {
    if (!$("#mainTab").tabs('exists', subtitle)) {
        $("#mainTab").tabs('add', {
            title: subtitle,
            content: createFrame(url),
            closable: true,
            icon: icon
        });
    } else {
        $("#mainTab").tabs('select', subtitle);
        $("#tab_menu-tabrefresh").trigger("click");
    }
    $(".layout-button-left").trigger("click");
    //tabClose();
}
function createFrame(url) {
    var s = '<iframe frameborder="0" src="' + url + '" scrolling="auto" style="width:100%; height:99%;padding:3px;"></iframe>';
    return s;
}


    $(function () {
        $(".ui-skin-nav .li-skinitem span").click(function () {
            var theme = $(this).attr("rel");
            $.messager.confirm('提示', '切換風格將重新加載系統！', function (r) {
                if (r) {
                    $.post("../../Home/SetThemes", { value: theme }, function (data) { window.location.reload(); }, "json");
                }
            });
        });
    });
