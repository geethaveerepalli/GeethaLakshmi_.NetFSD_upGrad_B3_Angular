var taskInput = document.getElementById("taskInput");
var addBtn = document.getElementById("addBtn");
var taskList = document.getElementById("taskList");

function addTask() {

    var taskText = taskInput.value;

    if (taskText === "") {
        alert("Please enter a task");
        return;
    }

    var li = document.createElement("li");
    li.innerHTML = taskText +
        " <button class='complete'>Done</button>" +
        " <button class='delete'>Delete</button>";

    taskList.appendChild(li);

    taskInput.value = "";
}


taskList.addEventListener("click", function(event) {

    if (event.target.className === "delete") {
        var li = event.target.parentElement;
        taskList.removeChild(li);
    }

    if (event.target.className === "complete") {
        var li = event.target.parentElement;
        li.style.textDecoration = "line-through";
    }
});
addBtn.addEventListener("click", addTask);