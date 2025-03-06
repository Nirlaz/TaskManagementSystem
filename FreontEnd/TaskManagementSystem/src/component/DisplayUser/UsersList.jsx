import { useRef } from "react";

const UserList = ({ UserData, handelDelete, handelUpdate, handelProject }) => {
  const UserName = useRef();
  return (
    <>
      <div className="row" style={{ margin: "10px", borderRadius: "2px" }}>
        <div className="col">{UserData.userId}</div>
        <div
          className="col"
          style={{ width: "100%", fontSize: "20px", padding: "2px" }}
        >
          <input
            className=" text-center"
            type="text"
            placeholder={`${UserData.userName}`}
            ref={UserName}
          />
        </div>
        <div className="col">
          <button
            type="button"
            className="btn btn-secondary"
            style={{ margin: "2px" }}
            onClick={(e) => handelProject(e, "projects", UserData)}
          >
            PROJECT
          </button>
        </div>
        <div className="col">
          <div className="btn-group" role="group" aria-label="Basic example">
            <button
              type="button"
              className="btn btn-success"
              style={{ margin: "2px" }}
              onClick={(e) => {
                handelUpdate(e, UserData.userId, UserName.current.value);
                UserName.current.value = "";
              }}
            >
              UPDATE
            </button>
            <button
              type="button"
              className="btn btn-danger"
              style={{ margin: "2px" }}
              onClick={(e) => handelDelete(e, UserData.userId)}
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
export default UserList;
