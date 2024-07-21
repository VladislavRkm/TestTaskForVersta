import { useEffect, useState } from 'react'
import './App.css';
import CreateOrderForm from './components/CreateOrderForm'
import Order from './components/Order'
import { createOrder, fetchOrders } from './services/orders';
import { Center } from '@chakra-ui/react';

function App() {
  const [orders, setOrders] = useState([]);
  
  useEffect(() => {
    const fetchData = async () => {
      let orders = await fetchOrders();
      setOrders(orders);
    };
    fetchData();
  }, []);

  const onCreate = async (order) => {
    await createOrder(order);
    let orders = await fetchOrders();
    setOrders(orders);
  };  

  return (
    <section className='p-8 flex flex-row justify-start items-start gap-12'>
      <div className="flex ">
        <CreateOrderForm onCreate={onCreate}/>
      </div>

      <ul className='flex flex-col gap-5 w-1/2'>
        {orders.map((n) => (
          <li key={n.id}>
            <Order 
              orderNumber={n.orderNumber} 
              senderCity={n.senderCity} 
              senderAddress={n.senderAddress}
              recipientCity={n.recipientCity}
              recipientAddress={n.recipientAddress}
              weight={n.weight}
              pickUpDate={n.pickUpDate}/>
          </li>

        ))}
        
      </ul>
      <footer style={{textAlign: "center"}}>
        Test task for Versta 2024 realised by Rakhmanov Vladislav
      </footer>

    </section>
    
  );
}

export default App
