import { useEffect, useState } from "react";
import {
  UrlAddTaskByProId,
  UrlDelTaskByTaskId,
  UrlGetTaskByProId,
  UrlUpdTaskByTaskId,
} from "../../Urls/Urls";

import TaskList from "./TaskList";
import TaskTitleBar from "./TaskTitleBar";
import UserDropDown from "../DisplayProject.jsx/UserDropDown";
import UserTitle from "../DisplayProject.jsx/UserTitle";
import AddItem from "../AddItem";

const DisplayTask = ({ projectId, projectName }) => {
  const [projectIdAtTask, setProjectIdAtTask] = useState(projectId);
  const [taskDatas, setTaskDatas] = useState([]);
  const fetchTaskDatas = async () => {
    if (projectIdAtTask != "") {
      const response = await fetch(`${UrlGetTaskByProId}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          projectId: projectIdAtTask,
        }),
      });
      setTaskDatas(await response.json());
    }
  };

  useEffect(() => {
    fetchTaskDatas();
  }, [projectIdAtTask, projectId, setProjectIdAtTask]);
  const handelAdd = async (e, taskName) => {
    e.preventDefault();
    if (taskName == null || taskName.trim() === "" || taskName === "") {
      alert("Task Name Required!!");
      return;
    }
    const response = await fetch(`${UrlAddTaskByProId}`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        projectId: projectIdAtTask,
        TaskName: taskName,
      }),
    });
    fetchTaskDatas();
  };

  const handelUpdate = async (e, id, taskName) => {
    e.preventDefault();
    if (taskName == null || taskName.trim() === "" || taskName === "") {
      alert("Task Name Required!!");
      return;
    }
    const response = await fetch(`${UrlUpdTaskByTaskId}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        taskId: id,
        taskName: taskName,
      }),
    });
    fetchTaskDatas();
  };
  const handelDelete = async (e, id) => {
    e.preventDefault();
    const response = await fetch(`${UrlDelTaskByTaskId}`, {
      method: "DELETE",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        taskId: id,
      }),
    });
    fetchTaskDatas();
  };
  return (
    <>
      <div className="disply-container">
        <div className="card " style={{ width: "100%" }}>
          <div className="card-body"></div>
          <div className="container text-center" style={{ width: "100%" }}>
            <div className="card-body "></div>
            <div className="container ">
              <div className="row center">
                <div className="col">
                  <UserTitle userName={projectName}></UserTitle>
                </div>
              </div>
            </div>

            <hr />
            <AddItem handelAdd={handelAdd}></AddItem>
            <hr />
            <TaskTitleBar></TaskTitleBar>
            <hr />
            {taskDatas.length > 0 &&
              taskDatas.map((task) => (
                <TaskList
                  key={task.taskId}
                  task={task}
                  handelDelete={handelDelete}
                  handelUpdate={handelUpdate}
                ></TaskList>
              ))}
            {taskDatas.length == 0 && <h1>Add Task For This Project</h1>}
            <hr />
          </div>
        </div>
      </div>
    </>
  );
};
export default DisplayTask;
