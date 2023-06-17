import React, { useEffect, useState } from 'react';
import './styles/App.css'
import OrderService from './Api/OrderService';
import { useFetching } from './hooks/useFetching';
import OrdersList from './components/OrderList/OrdersList';
import CreateOrderForm from './components/CreateOrderForm/CreateOrderForm';
import Modal from './components/UI/Modal/Modal';
import Button from './components/UI/Button/Button';
import ShowOrder from './components/ShowOrder/ShowOrder';
import Loader from './components/UI/Loader/Loader';


const App = () => {
    const [modalCreateShow,setModalCreateShow] = useState(false);


    const [modalCreate,setModalCreate] = useState(false);
    const [createOrder,setCreateOrder] = useState();
    const [diabledButCreate, setDiabledButCreate] = useState(true);

    const [orders,setOrders] = useState([]);
    const [orderShow, setOrderShow] = useState({ 
        id:0,
        senderСity:'',
        senderAddres:'',
        recipientCity:'',
        recipientAddres:'',
        weightCargo: 0,
        pickupDate:''});
        
    const [modalOrderShow,setModalOrderShow] = useState(false);

    const [fetchingCreate, isLoadingCreate, errorCreate] = useFetching(async () =>{
        const response = await OrderService.createOrder(createOrder);
        setOrderShow(response.data);
        console.log(response);
    })

    const [fetchingOrders, isLoadingorders, errorOrders] = useFetching(async () =>{
        const response = await OrderService.getAll();
        const sortOrders = response.data.orders.sort( (a, b) => b.id - a.id)
        setOrders(sortOrders);
        console.log(response);
    })

    useEffect(()=>{
        fetchingOrders();
    },[])

    useEffect(()=>{
        if(!createOrder) return;
        const cr = async () =>{ 
            setModalCreate(false);
            await fetchingCreate();
            await fetchingOrders();

            setModalCreateShow(true);
        }
        cr();
    },[createOrder])

    useEffect( ()=>{
        if(errorOrders) {
            setDiabledButCreate(true);
        } else {
            setDiabledButCreate(false);
        }
    },[errorOrders])

   const create = (order) => {
        setCreateOrder(order);
   }
   const showOrderById = (id) => {
        setOrderShow(orders.find(o=>o.id === id))
        setModalOrderShow(true)
   }

  return (
    <div className='App'>
        <Button disabled={diabledButCreate} style={{marginTop:'10px'}} onClick={()=>{setModalCreate(true)}}>Добавить заказ</Button>

        <Modal visible={modalCreate} setVisible={setModalCreate}>
            <CreateOrderForm create={create}></CreateOrderForm>
        </Modal>

        <Modal visible={modalCreateShow} setVisible={setModalCreateShow}>
            <ShowOrder title={`Создан заказ №${orderShow.id}`} order={orderShow}></ShowOrder>
        </Modal>

        <Modal visible={modalOrderShow} setVisible={setModalOrderShow}>
            <ShowOrder title={`Заказ №${orderShow.id}`} order={orderShow}></ShowOrder>
        </Modal>

        
        <OrdersList showOrderById={showOrderById} orders={orders} />
        {isLoadingorders&& <div className='loader'><Loader/></div>}
        {errorOrders&& <div className='loader' >Ошибка: {errorOrders}. Подключение с сервером отсутствует. Обновите страницу.</div>}
    </div>
  )
}

export default App
