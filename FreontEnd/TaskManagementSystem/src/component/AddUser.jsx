import { useRef } from "react";
import { UrlAddNewUser } from "../Urls/Urls";

const AddUser = ({ handelAdd }) => {
  const UserName = useRef();
  return (
    <>
      <div className="row" style={{ margin: "10px", borderRadius: "2px" }}>
        <div className="col-8">
          <input
            type="text"
            className=" text-center"
            placeholder="Enter New UserName"
            ref={UserName}
            style={{ width: "100%", fontSize: "20px", padding: "4px" }}
          />
        </div>
        <div className="col-4">
          <button
            type="button"
            className="btn btn-success"
            style={{ margin: "2px", width: "100%" }}
            onClick={(e) => {
              handelAdd(e, UserName.current.value);
              UserName.current.value = "";
            }}
          >
            ADD
          </button>
        </div>
      </div>
    </>
  );
};
export default AddUser;
