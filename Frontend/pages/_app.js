import "../styles/globals.css";
import Navbar from "../components/Navbar";
import { useRouter } from "next/router";
import { useEffect,useState } from "react";
import axios from "axios";
import { GetAuthtoken } from "../scripts/Auth";
import Cookies from "js-cookie";

export default function MyApp({ Component, pageProps }) {
  const [authinf,setAuthinf] = useState(-1);
  const router = useRouter();
  useEffect(() => {
    if(typeof window !== "undefined"){
      if (router.pathname !== "/login" && router.pathname !== "/register") {
        axios
          .get("http://localhost:11738/Login/" + Cookies.get("authtoken"))
          .then((response) => {setAuthinf(response.data)})
          .catch((e) => {});
      }
    }
  }, [router,typeof window]);
  return (
    <>
      <Navbar />
      <Component {...pageProps} auth={authinf} />
    </>
  );
}
