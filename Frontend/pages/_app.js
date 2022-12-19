import "../styles/globals.css";
import Navbar from "../components/navbar";
import { useRouter } from "next/router";
import { useEffect, useState } from "react";
import axios from "axios";
import Cookies from "js-cookie";

export default function MyApp({ Component, pageProps }) {
  const [authinf, setAuthinf] = useState({});
  const router = useRouter();

  useEffect(() => {
    if (typeof window !== "undefined") {
      if (
        router.pathname !== "logout" &&
        router.pathname !== "/login" &&
        router.pathname !== "/register"
      ) {
        axios
          .get("http://localhost:11738/Login/" + Cookies.get("authtoken"))
          .then((response) => {
            if (response.data === -1) {
              router.push("/login");
            } else {
              setAuthinf(response.data);
            }
          })
          .catch(() => {
            router.push("/login");
          });
      }
    }
  }, [router, typeof window]);

  return (
    <>
      {router.pathname !== "/login" ? <Navbar authtype={authinf} /> : <></>}
      <Component {...pageProps} auth={authinf} />
    </>
  );
}
