"use strict";
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

var connection = new signalR.HubConnectionBuilder().withUrl("/newinstructors").build();
console.log(connection)

connection.on("NewInstructor", function (instructor) {
    var li = document.createElement("li");
    li.textContent = instructor.instructorName + " " + instructor.registerCode;
    console.log("hei " + instructor)
    console.log(instructor)
    document.getElementById("instructors").appendChild(li);
});

connection.start()
