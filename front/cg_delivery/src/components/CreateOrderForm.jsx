import { Button, Input } from '@chakra-ui/react';
import { useState } from 'react';
export default function CreateOrderForm({onCreate}) {
    const [order, setOrder] = useState(null);
    const onSubmit = (e) => {
      <e className="preventDefault"></e>
      setOrder(null);
      onCreate(order);
    };

    return (
        <form onSubmit={onSubmit} className="flex flex-col gap-3 w-1/3">
          <h3 className="font-bold text-xl">Создание заказа</h3>
            <Input 
              placeholder="Город получателя"
              value={order?.senderCity ?? ""} 
              onChange={(e) => setOrder({...order, senderCity: e.target.value})}
            />
            <Input  
              placeholder="Адрес получателя" 
              value={order?.senderAddress ?? ""} 
              onChange={(e) => setOrder({...order, senderAddress: e.target.value})}
            />
            <Input 
              placeholder="Город отправителя"
              value={order?.recipientCity ?? ""} 
              onChange={(e) => setOrder({...order, recipientCity: e.target.value})}
            />
            <Input 
              placeholder="Адрес отправителя"
              value={order?.recipientAddress ?? ""} 
              onChange={(e) => setOrder({...order, recipientAddress: e.target.value})}
            />
            <Input 
              placeholder="Вес" type="number"
              value={order?.weight ?? 0} 
              onChange={(e) => setOrder({...order, weight: e.target.value})}
            />
            <Input 
              placeholder="Дата забора груза" size='md' type='datetime-local' 
              value={order?.pickUpDate?? ""} 
              onChange={(e) => setOrder({...order, pickUpDate: e.target.value})}
            />
            <Button type="submit" colorScheme='teal'>Отправить</Button>
        </form>
    );
  }