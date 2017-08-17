// list.min.js options
// 
// var options = {
//         valueNames: [ 'lis-emp-name' ]
//     };

//     var userList = new List('lis-emp-search', options);


var options = {
  valueNames: [ 'name', 'city' ]
};

var hackerList = new List('hacker-list', options);

alert("list loaded");

 $("#pants").click(function(){
    $("#hacker-list").addClass("fancy-pants");
});