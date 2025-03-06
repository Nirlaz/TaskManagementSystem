const SideBar = ({ currnetTab, setCurrentTab }) => {
  const handelTab = (e) => {
    e.preventDefault();
    console.log(e);
  };

  return (
    <>
      <div
        className="d-flex flex-column flex-shrink-0 p-3 text-bg-dark sidebars"
        style={{ width: "280px" }}
      >
        <a
          href="/"
          className="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-white text-decoration-none"
        >
          <svg className="bi pe-none me-2" width="40" height="32">
            <use xlinkHref="#bootstrap"></use>
          </svg>
          <span className="fs-4">Task Manger</span>
        </a>
        <hr />
        <ul className="nav nav-pills flex-column mb-auto">
          <li className="nav-item" onClick={(e) => setCurrentTab("home")}>
            <a
              href="#home"
              className={`${
                currnetTab == "home" ? "active" : "text-white"
              }  nav-link`}
              aria-current="page"
            >
              <svg className="bi pe-none me-2" width="16" height="16">
                <use xlinkHref="#home"></use>
              </svg>
              Display Users
            </a>
          </li>
          <li onClick={() => setCurrentTab("projects")}>
            <a
              href="#"
              className={`${
                currnetTab == "projects" ? "active" : "text-white"
              }  nav-link`}
            >
              <svg className="bi pe-none me-2" width="16" height="16">
                <use xlinkHref="#projects"></use>
              </svg>
              Projects
            </a>
          </li>
          <li onClick={() => setCurrentTab("task")}>
            <a
              href="#"
              className={`${
                currnetTab == "task" ? "active" : "text-white"
              }  nav-link`}
            >
              <svg className="bi pe-none me-2" width="16" height="16">
                <use xlinkHref="#tasks"></use>
              </svg>
              Tasks
            </a>
          </li>
        </ul>
        <hr />
      </div>
    </>
  );
};
export default SideBar;
