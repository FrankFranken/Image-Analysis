




    $(function() {
        var params = {
        };

        $.ajax({
            url: "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?" + $.param(params),
            beforeSend: function(xhrObj) {
                // Request headers
                xhrObj.setRequestHeader("Content-Type", "application/json");
                xhrObj.setRequestHeader("Ocp-Apim-Subscription-Key", "{36fc859b900345c787435bbf2fd62278 }");
            },
            type: "POST",
            // Request body
            data: "{body}",
        })
            .done(function(data) {
                alert("success");
            })
            .fail(function() {
                alert("Shit it didn't work");
            });
    });