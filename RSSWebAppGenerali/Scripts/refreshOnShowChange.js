
$(document).ready(function () {
    $("#ModelDropDownList").change(function () {
        $.ajax({
            type: 'GET',
            url: 'News/GetRSSByTitle',
            dataType: 'json',
            data: { title: $("#ModelDropDownList").val() },

            success: function (RSSDto) {
                $("#tables").empty();
                //console.log(RSSDto);
                $.each(RSSDto, function (i, rssDto) {
                    createTable(rssDto.Category, rssDto.RssList);
            });
            },
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
        return false;
    })
});


function createTable(title, lists) {
    var divPage = document.getElementById('tables');

    var bigTitleH2 = document.createElement('h2');
    bigTitleH2.innerHTML = title;
    divPage.appendChild(bigTitleH2);

    var hr_object = document.createElement('hr');
    divPage.appendChild(hr_object);
    
    var mytable = document.createElement("table");
    mytable.classList.add("table");

    //head
    var mytablehead = document.createElement("thead")
    var head_row = document.createElement("tr");

    var title_head = document.createElement("th");
    title_head.textContent = "Title";
    var description_head = document.createElement("th");
    description_head.textContent = "Description";
    var link_head = document.createElement("th");
    link_head.textContent = "Link";
    var publish_head = document.createElement("th");
    publish_head.textContent = "Publish Date";
    var empty_head = document.createElement("th");

    head_row.appendChild(title_head);
    head_row.appendChild(description_head);
    head_row.appendChild(link_head);
    head_row.appendChild(publish_head);
    head_row.appendChild(empty_head);

    mytablehead.appendChild(head_row);

    //body
    var mytablebody = document.createElement("tbody");

    for (var i = 0; i < lists.length; i++) {
        var mycurrent_row = document.createElement("tr");

        var title_cell = document.createElement("td");
        title_cell.innerHTML  = lists[i].Title;
        var desc_cell = document.createElement("td");
        desc_cell.innerHTML  = lists[i].Description;
        var link_cell = document.createElement("td");
        var link_a = document.createElement("a");
        link_a.setAttribute("href", lists[i].Link);
        link_a.innerHTML = "Ugrás a teljes hírhez";
        link_cell.appendChild(link_a);
        var pubDate_cell = document.createElement("td");
        pubDate_cell.innerHTML  = lists[i].PubDate;
        var fav_cell = document.createElement("td");
        fav_cell.innerHTML  = lists[i].Favourite;


        mycurrent_row.appendChild(title_cell);
        mycurrent_row.appendChild(desc_cell);
        mycurrent_row.appendChild(link_cell);
        mycurrent_row.appendChild(pubDate_cell);
        mycurrent_row.appendChild(fav_cell);
        
        mytablebody.appendChild(mycurrent_row);
    }

    mytable.appendChild(mytablehead);
    mytable.appendChild(mytablebody);

    divPage.appendChild(mytable);
}