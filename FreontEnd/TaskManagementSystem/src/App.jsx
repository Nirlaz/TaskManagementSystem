import "bootstrap/dist/css/bootstrap.min.css";
import {
  UrlAddNewUser,
  UrlDeleteUserById,
  UrlGetAllUsers,
  UrlUpdateUserById,
} from ".//Urls/Urls";
import { useEffect, useState } from "react";
import { v4 as uuidv4 } from "uuid";
import Header from "./component/Header";
import SideBar from "./component/SideBar";
import "./App.css";
import Footer from "./component/Footer";
import DisplayUsers from "./component/DisplayUser/DisplayUser";
import DisplayProjects from "./component/DisplayProject.jsx/DisplayProjects";
import DisplayTask from "./component/DisplayTask/DisplayTask";
function App() {
  const [currnetTab, setCurrentTab] = useState("home");
  const [userId, setUserId] = useState("");
  const [userName, setUserName] = useState("");
  const [projectId, setProjectId] = useState("");
  const [projectName, setProjectName] = useState("");
  const [userDatas, setUserData] = useState([]);

  const fetchData = async () => {
    fetch(`${UrlGetAllUsers}`)
      .then((res) => res.json())
      .then((data) => setUserData(data));
  };
  useEffect(() => {
    fetchData();
  }, []);
  const handelUserDelete = async (e, id) => {
    e.preventDefault();
    const response = await fetch(`${UrlDeleteUserById}`, {
      method: "DELETE",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        UserId: id,
      }),
    });
    fetchData();
  };
  const handelUserUpdate = async (e, id, userName) => {
    e.preventDefault();
    if (userName == null || userName.trim() === "" || userName === "") {
      alert("UserName Required!!");
      return;
    }
    const response = await fetch(`${UrlUpdateUserById}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        UserId: id,
        UserName: userName,
      }),
    });
    fetchData();
  };
  const handelUserAdd = async (e, userName) => {
    e.preventDefault();
    if (userName == null || userName.trim() === "" || userName === "") {
      alert("UserName Required!!");
      return;
    }
    const response = await fetch(`${UrlAddNewUser}`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        UserId: uuidv4(),
        UserName: userName,
      }),
    });
    fetchData();
  };

  const handelProject = (e, currentTab, user) => {
    setCurrentTab(currentTab);
    setUserId(user.userId);
    setUserName(user.userName);
  };

  const handelTask = (e, currentTab, project) => {
    setCurrentTab(currentTab);
    setProjectId(project.projectId);
    setProjectName(project.projectName);
  };
  return (
    <>
      <div className="app-container">
        <SideBar
          currnetTab={currnetTab}
          setCurrentTab={setCurrentTab}
        ></SideBar>
        <div className="content">
          <Header></Header>
          {currnetTab === "home" && (
            <DisplayUsers
              handelProject={handelProject}
              userDatas={userDatas}
              handelAdd={handelUserAdd}
              handelDelete={handelUserDelete}
              handelUpdate={handelUserUpdate}
            ></DisplayUsers>
          )}
          {currnetTab === "projects" && (
            <DisplayProjects
              userName={userName}
              userId={userId}
              userDatas={userDatas}
              handelTask={handelTask}
              setUserName={setUserName}
            ></DisplayProjects>
          )}
          {currnetTab === "task" && (
            <DisplayTask
              projectId={projectId}
              projectName={projectName}
            ></DisplayTask>
          )}
          <Footer></Footer>
        </div>
      </div>
    </>
  );
}

export default App;
