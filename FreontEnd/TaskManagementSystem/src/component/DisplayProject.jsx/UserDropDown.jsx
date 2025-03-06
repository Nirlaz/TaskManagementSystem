import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min"; // For Bootstrap JS functionality

const UserDropDown = ({ userDatas, handelUserChange }) => {
  return (
    <div className="dropdown">
      <button
        className="btn btn-secondary dropdown-toggle"
        type="button"
        id="dropdownMenuButton"
        data-bs-toggle="dropdown"
        aria-expanded="false"
        style={{ width: "100%", fontSize: "20px", padding: "4px" }}
      >
        USERS
      </button>
      <ul
        className="dropdown-menu text-center"
        aria-labelledby="dropdownMenuButton"
        style={{ width: "100%", fontSize: "20px", padding: "4px" }}
      >
        {userDatas.map((user) => (
          <li key={user.userId}>
            <a
              className="dropdown-item"
              href="#"
              onClick={(e) => {
                e.preventDefault();

                handelUserChange(user); // Handle user selection
              }}
            >
              {user.userName}
            </a>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default UserDropDown;
