import "../styles/globals.css";
import Navbar from "../components/navbar";
import { useRouter } from "next/router";
import { useEffect, useState } from "react";
import axios from "axios";
import Cookies from "js-cookie";

export default function MyApp({ Component, pageProps }) {
  const [authinf, setAuthinf] = useState(-1);
  const router = useRouter();
  useEffect(() => {
    if (typeof window !== "undefined") {
      if (router.pathname !== "/login" && router.pathname !== "/register") {
        axios
          .get("http://localhost:11738/Login/" + Cookies.get("authtoken"))
          .then((response) => {
            if (response.data === -1) {
              router.push("/login");
            } else {
              setAuthinf(response.data);
            }
          })
          .catch((e) => {
            router.push("/login");
          });
      }
    }
  }, [router, typeof window]);
  return (
    <>
      <Navbar authtypeid={authinf} />
      <Component {...pageProps} auth={authinf} />
    </>
  );
}
