import { Card, CardBody, CardFooter, CardHeader, Divider, Heading, } from '@chakra-ui/react';
import moment from 'moment/moment';
export default function Order({orderNumber,senderCity, senderAddress, recipientCity, recipientAddress, weight, pickUpDate}) {
    return (
        <Card variant={"filled"}>
          <CardHeader>
            <Heading size={"md"}>{orderNumber}</Heading>
          </CardHeader>
          <Divider borderColor={"gray"} />
          <CardBody>{senderCity}</CardBody>
          <CardBody>{senderAddress}</CardBody>
          <CardBody>{recipientCity}</CardBody>
          <CardBody>{recipientAddress}</CardBody>
          <CardBody>{weight}</CardBody>
          <CardFooter>{moment(pickUpDate).format("DD/MM/YYYY h:mm:ss")}</CardFooter>
          <Divider borderColor={"teal"} />
        </Card>
    )
}