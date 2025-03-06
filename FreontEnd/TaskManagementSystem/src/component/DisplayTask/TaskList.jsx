import { useRef } from "react";

const TaskList = ({ task, handelDelete, handelUpdate }) => {
  const TaskName = useRef("");
  return (
    <>
      <div className="row" style={{ margin: "10px", borderRadius: "2px" }}>
        <div className="col">{task.taskId}</div>
        <div
          className="col"
          style={{ width: "100%", fontSize: "20px", padding: "2px" }}
        >
          <input
            className=" text-center"
            type="text"
            placeholder={task.taskName}
            ref={TaskName}
          />
        </div>
        <div className="col">
          <div className="btn-group" role="group" aria-label="Basic example">
            <button
              type="button"
              className="btn btn-success"
              style={{ margin: "2px" }}
              onClick={(e) => {
                handelUpdate(e, task.taskId, TaskName.current.value);
                TaskName.current.value = "";
              }}
            >
              UPDATE
            </button>
            <button
              type="button"
              className="btn btn-danger"
              style={{ margin: "2px" }}
              onClick={(e) => handelDelete(e, task.taskId)}
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
export default TaskList;
