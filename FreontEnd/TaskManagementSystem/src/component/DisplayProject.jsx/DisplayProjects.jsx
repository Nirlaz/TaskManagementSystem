import { useEffect, useState } from "react";
import ProjectTitleBar from "./ProjectTitleBar";
import {
  UrlAddProByUserId,
  UrlDelProByProId,
  UrlGetProByUserId,
  UrlUptProByProId,
} from "../../Urls/Urls";
import ProjectList from "./ProjectList";
import UserDropDown from "./UserDropDown";
import UserTitle from "./UserTitle";
import AddItem from "../AddItem";

const DisplayProjects = ({
  userDatas,
  userId,
  handelTask,
  userName,
  setUserName,
}) => {
  const [userIdAtProject, setUserIdAtProject] = useState(userId);
  const [projectDatas, setProjectDatas] = useState([]);
  const fetchProjectData = async () => {
    if (userIdAtProject != "") {
      const response = await fetch(
        "http://localhost:5233/Project/GetProByUserId",
        {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            userId: userIdAtProject,
          }),
        }
      );
      setProjectDatas(await response.json());
    }
  };

  useEffect(() => {
    fetchProjectData();
  }, [userIdAtProject, userId, setUserIdAtProject]);
  const handelUserChange = (user) => {
    setUserIdAtProject(user.userId);
    setUserName(user.userName);
    fetchProjectData();
  };
  const handelUpdate = async (e, id, projectName) => {
    e.preventDefault();
    if (
      projectName == null ||
      projectName.trim() === "" ||
      projectName === ""
    ) {
      alert("projectName Required!!");
      return;
    }
    const response = await fetch(`${UrlUptProByProId}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        projectId: id,
        projectName: projectName,
      }),
    });
    fetchProjectData();
  };
  const handelDelete = async (e, id) => {
    e.preventDefault();
    const response = await fetch(`${UrlDelProByProId}`, {
      method: "DELETE",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        projectId: id,
      }),
    });
    fetchProjectData();
  };
  const handelAdd = async (e, projectName) => {
    e.preventDefault();
    if (
      projectName == null ||
      projectName.trim() === "" ||
      projectName === ""
    ) {
      alert("projectName Required!!");
      return;
    }
    const response = await fetch(`${UrlAddProByUserId}`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        userId: userIdAtProject,
        projectName: projectName,
      }),
    });
    fetchProjectData();
  };

  return (
    <>
      <div className="disply-container">
        <div className="card text-center" style={{ width: "100%" }}>
          <div className="card-body "></div>
          <div className="container ">
            <div className="row center">
              <div className="col-9">
                <UserTitle userName={userName}></UserTitle>
              </div>
              <div className="col-3">
                <UserDropDown
                  userDatas={userDatas}
                  handelUserChange={handelUserChange}
                ></UserDropDown>
              </div>
            </div>
          </div>

          <hr />
         <AddItem handelAdd={handelAdd}></AddItem>
          <hr />
          <ProjectTitleBar></ProjectTitleBar>
          <hr />
          {projectDatas.length > 0 &&
            projectDatas.map((ProjectData) => (
              <ProjectList
                key={ProjectData.projectId}
                handelDelete={handelDelete}
                handelUpdate={handelUpdate}
                handelTask={handelTask}
                ProjectData={ProjectData}
              ></ProjectList>
            ))}
          {projectDatas == 0 && <h1 className="text-center">Add Project</h1>}
          <hr />
        </div>
      </div>
    </>
  );
};
export default DisplayProjects;
