import { useRef } from "react";

const AddItem = ({ handelAdd }) => {
  const ItemName = useRef();
  return (
    <>
      <div className="row" style={{ margin: "10px", borderRadius: "2px" }}>
        <div className="col-8">
          <input
            className=" text-center"
            type="text"
            placeholder="Enter New Entry"
            ref={ItemName}
            style={{ width: "100%", fontSize: "20px", padding: "4px" }}
          />
        </div>
        <div className="col-4">
          <button
            type="button"
            className="btn btn-success"
            style={{ margin: "2px", width: "100%" }}
            onClick={(e) => {
              e.preventDefault();
              handelAdd(ItemName.current.value);
              ItemName.current.value = "";
            }}
          >
            ADD
          </button>
        </div>
      </div>
    </>
  );
};
export default AddItem;
