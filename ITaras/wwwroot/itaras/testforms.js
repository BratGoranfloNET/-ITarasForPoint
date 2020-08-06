function ButtonsForms(numberOfItems) {      
    var loadStatus = [];
    for (i = 0; i < numberOfItems; i++) {        
       loadStatus.push(false);       
    } 
    this.buttons = [];     
    this.loadData = function () {       
        var id = this.id.replace("button-", "");        
        for (i = 0; i < numberOfItems; i++) {
            if ((i + 1).toString() == id) {                               
                $("#form-"+(i+1)).show();
            }
            else{                
                $("#form-"+(i+1)).hide();
            }               
        }            
        var url = '/Form' + id + '/GetData';
        if (!loadStatus[id - 1]) {
            $("#spinner-test").show(); 
            $.ajax({
                url: url,
                type: 'POST',
                dataType: 'json',
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(),
                success: function (response) {
                    $("#dataform"+id).text(response.messages); 
                    $("#statusform"+id).text("Загружена");
                    loadStatus[id-1] = true;
                    $("#spinner-test").hide(); 
                },
                error: function (err) { alert("Error: " + err.responseText); }
            });
        }
    };  
    for (i = 0; i < numberOfItems; i++) {
        this.buttons.push(document.getElementById("button-" + (i + 1)));
        this.buttons[i].onclick = this.loadData;
    } 
};

$(document).ready(function () {
    var testform = new ButtonsForms(3);
    testform.buttons[0].click();   

    document.getElementById("other-button").onclick = function () {       
        testform.buttons[0].click();
    };     
});

