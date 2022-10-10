import "../styles/globals.css";
import Navbar from "../components/Navbar";
import { useRouter } from "next/router";
import { useEffect } from "react";
import axios from "axios";
import { GetAuthtoken } from "../scripts/Auth";

export default function MyApp({ Component, pageProps }) {
  const router = useRouter();
  useEffect(() => {

  if (router.pathname !== "/login" && router.pathname !== "/register") {
    axios
      .get("http://localhost:11738/Login/" + GetAuthtoken())
      .then(() => {})
      .catch(() => router.push("/login"));
  }
  }, [router]);
  return (
    <>
      <Navbar />
      <Component {...pageProps} />
    </>
  );
}
