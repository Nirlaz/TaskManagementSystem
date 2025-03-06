const ProjectTitleBar = () => {
  return (
    <>
      <div className="row" style={{ margin: "10px", borderRadius: "2px" }}>
        <div className="col" style={{ backgroundColor: "#33333357" }}>
          ID
        </div>
        <div className="col" style={{ backgroundColor: "#33333357" }}>
          Project Name
        </div>
        <div className="col" style={{ backgroundColor: "#33333357" }}>
          Tasks
        </div>
        <div className="col" style={{ backgroundColor: "#33333357" }}>
          Action
        </div>
      </div>
    </>
  );
};
export default ProjectTitleBar;
