import { useRef } from "react";

const ProjectList = ({
  ProjectData,
  handelDelete,
  handelUpdate,
  handelTask,
}) => {
  const ProjectName = useRef("");
  return (
    <>
      <div className="row" style={{ margin: "10px", borderRadius: "2px" }}>
        <div className="col">{ProjectData.projectId}</div>
        <div
          className="col"
          style={{ width: "100%", fontSize: "20px", padding: "2px" }}
        >
          <input
            className=" text-center"
            type="text"
            placeholder={`${ProjectData.projectName}`}
            ref={ProjectName}
          />
        </div>
        <div className="col">
          <button
            type="button"
            className="btn btn-secondary"
            style={{ margin: "2px" }}
            onClick={(e) => handelTask(e, "task", ProjectData)}
          >
            Task
          </button>
        </div>
        <div className="col">
          <div className="btn-group" role="group" aria-label="Basic example">
            <button
              type="button"
              className="btn btn-success"
              style={{ margin: "2px" }}
              onClick={(e) => {
                handelUpdate(
                  e,
                  ProjectData.projectId,
                  ProjectName.current.value
                );
                ProjectName.current.value = "";
              }}
            >
              UPDATE
            </button>
            <button
              type="button"
              className="btn btn-danger"
              style={{ margin: "2px" }}
              onClick={(e) => handelDelete(e, ProjectData.projectId)}
            >
              DELETE
            </button>
          </div>
        </div>
      </div>
      <hr />
    </>
  );
};
export default ProjectList;
