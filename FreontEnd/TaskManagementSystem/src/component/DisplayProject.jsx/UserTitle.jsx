const UserTitle = ({ userName }) => {
  return (
    <>
      <input
        className=" text-center"
        type="text"
        readOnly
        placeholder="USERS"
        value={userName}
        style={{ width: "100%", fontSize: "20px", padding: "4px" }}
      />
    </>
  );
};
export default UserTitle;
