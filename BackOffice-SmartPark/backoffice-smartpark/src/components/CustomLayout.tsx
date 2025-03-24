import { Layout } from "react-admin";
import CustomMenu from "./CustomMenu";

const CustomLayout = (props: any) => <Layout {...props} menu={CustomMenu} />;

export default CustomLayout;
