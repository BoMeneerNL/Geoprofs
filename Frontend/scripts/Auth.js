import axios from "axios";
// @ts-ignore-next-line
import Cookies from "js-cookie";

export async function CheckAuthtoken() {
  const authtoken = GetAuthtoken();
  let returner;
  await axios
    .get(`https://localhost:44352/checktoken/${authtoken}/${currentPage}`)
    .then(() => (returner = 200))
    .catch((error) => {
      if (error.response.status === 403) {
        returner = 403;
      } else {
        returner = 401;
      }
    });
  if (returner === undefined) {
    returner = 401;
  }
  return returner;
}
export function GetAuthtoken() {
  return Cookies.get("authtoken");
}
