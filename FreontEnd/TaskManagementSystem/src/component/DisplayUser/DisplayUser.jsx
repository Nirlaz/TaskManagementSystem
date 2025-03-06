import TitleBar from "./TitleBar";
import UserList from "./UsersList";

import AddItem from "../AddItem";

const DisplayUsers = ({
  handelProject,
  handelAdd,
  handelDelete,
  userDatas,
  handelUpdate,
}) => {
  return (
    <>
      <div className="disply-container">
        <div className="card " style={{ width: "100%" }}>
          <div className="card-body"></div>
          <div className="container text-center">
            <hr />
            <AddItem handelAdd={handelAdd}></AddItem>
            <hr />
            <TitleBar></TitleBar>
            <hr />
            {userDatas.length > 0 &&
              userDatas.map((userData) => (
                <UserList
                  key={userData.userId}
                  UserData={userData}
                  handelDelete={handelDelete}
                  handelUpdate={handelUpdate}
                  handelProject={handelProject}
                ></UserList>
              ))}
            {userDatas.length == 0 && <h1>Enter Data</h1>}
          </div>
        </div>
      </div>
    </>
  );
};
export default DisplayUsers;
