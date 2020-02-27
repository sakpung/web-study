$(document).ready(function () {

   function createStatEntry(key, val, setError) {
      var $label = $(document.createElement("label")).text(key);
      var $val = $(document.createElement("span")).text(val);
      if (setError) $val.addClass("error")
      return $(document.createElement("div")).append($label).append($val);
   }

   // Ping
   var $pingStats = $("#pingStats");
   var $refreshPingStatistics = $("#refreshPingStatistics");
   var pingResults = [
      { label: "Was License Checked: ", key: "isLicenseChecked", errVal: false },
      { label: "Is License Expired: ", key: "isLicenseExpired", errVal: true },
      { label: "Kernel Type: ", key: "kernelType", errVal: "Evaluation" },
   ];
   var refreshPingInfo = function () {
      $pingStats.addClass("hide");
      $refreshPingStatistics.prop('disabled', true);
      $.ajax("./api/Test/Ping", {
         headers: { 'cache-control': 'no-cache' }
      }).fail(function (jqXHR) {
         console.log(jqXHR);
         $pingStats.empty().text("The ping statistics could not be retrieved. Check the console.");
      }).done(function (result) {
         $pingStats.empty();
         if (result) {
            pingResults.forEach(function (keyValOb) {
               var val = result[keyValOb.key];
               if (val != null && val != undefined) {
                  $pingStats.append(createStatEntry(keyValOb.label, val, val === keyValOb.errVal));
               }
            })
            if (result["time"]) {
               var $label = $(document.createElement("label")).text("Updated: ");
               var $val = $(document.createElement("span")).text(new Date(result["time"]).toTimeString());
               var $holder = $(document.createElement("div")).append($label).append($val);
               $pingStats.append($holder);
            }
         }
         else
            $pingStats.empty().text("No ping data could be read.");
      }).always(function () {
         setTimeout(function () {
            $pingStats.removeClass("hide");
            $refreshPingStatistics.prop('disabled', false);
         }, 500)
      })
   }
   refreshPingInfo();
   $refreshPingStatistics.click(refreshPingInfo);

   
})