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
                window.location = "/Account/Login";
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
    var s = '<iframe frameborder="0" src="' + url + '"?IEguid="' + GetGuid() + '" scrolling="auto" style="width:100%; height:100%;padding:3px;"></iframe>';
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

    //生成唯一的GUID
    function GetGuid() {
        var s4 = function () {
            return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        };
        return s4() + s4() + s4() + "-" + s4();
    }

//除法函數，用來得到精確的除法結果
// 說明：javascript的除法結果會有誤差，在兩個浮點數相除的時候會比較明顯。這個函數返回較為精確的除法結果。
//調用：accDiv(arg1,arg2)
//返回值：arg1除以arg2的精確結果
function accDiv(arg1, arg2) {
         var t1 = 0, t2 = 0, r1, r2;
         try { t1 = arg1.toString().split(".")[1].length } catch (e) { }
         try { t2 = arg2.toString().split(".")[1].length } catch (e) { }
         with (Math) {
             r1 = Number(arg1.toString().replace(".", ""))
             r2 = Number(arg2.toString().replace(".", ""))
             return (r1 / r2) * pow(10, t2 - t1);
         }
     }

//給Number類型增加一個div方法，調用起來更加方便。
Number.prototype.div = function(arg) {
         return accDiv(this, arg);
     }

//乘法函數，用來得到精確的乘法結果
//說明：javascript的乘法結果會有誤差，在兩個浮點數相乘的時候會比較明顯。這個函數返回較為精確的乘法結果。
//調用：accMul(arg1,arg2)
//返回值：arg1乘以 arg2的精確結果
function accMul(arg1, arg2) {
         var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
         try { m += s1.split(".")[1].length } catch (e) { }
         try { m += s2.split(".")[1].length } catch (e) { }
         return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m)
     }

// 給Number類型增加一個mul方法，調用起來更加方便。
Number.prototype.mul = function(arg) {
         return accMul(arg, this);
     }

//加法函數，用來得到精確的加法結果
//說明：javascript的加法結果會有誤差，在兩個浮點數相加的時候會比較明顯。這個函數返回較為精確的加法結果。
//調用：accAdd(arg1,arg2)
// 返回值：arg1加上arg2的精確結果
function accAdd(arg1, arg2) {
         var r1, r2, m, c;
         try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
         try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
         c = Math.abs(r1 - r2);
         m = Math.pow(10, Math.max(r1, r2))
         if (c > 0) {
             var cm = Math.pow(10, c);
             if (r1 > r2) {
                 arg1 = Number(arg1.toString().replace(".", ""));
                 arg2 = Number(arg2.toString().replace(".", "")) * cm;
             }
             else {
                 arg1 = Number(arg1.toString().replace(".", "")) * cm;
                 arg2 = Number(arg2.toString().replace(".", ""));
             }
         }
         else {
             arg1 = Number(arg1.toString().replace(".", ""));
             arg2 = Number(arg2.toString().replace(".", ""));
         }
         return (arg1 + arg2) / m
     }

//給Number類型增加一個add方法，調用起來更加方便。
Number.prototype.add = function(arg) {
         return accAdd(arg, this);
     }
//減法函數，用來得到精確的減法結果
//說明：javascript的減法結果會有誤差，在兩個浮點數相減的時候會比較明顯。這個函數返回較為精確的減法結果。
//調用：accSub(arg1,arg2)
// 返回值：arg1加上arg2的精確結果
function accSub(arg1,arg2){
　　 var r1,r2,m,n;
　　 try{r1=arg1.toString().split(".")[1].length}catch(e){r1=0}
　　 try{r2=arg2.toString().split(".")[1].length}catch(e){r2=0}
　　 m=Math.pow(10,Math.max(r1,r2));
　　 //last modify by deeka
　　 //動態控制精度長度
　　 n=(r1>=r2)?r1:r2;
　　 return ((arg1*m-arg2*m)/m).toFixed(n);
}

