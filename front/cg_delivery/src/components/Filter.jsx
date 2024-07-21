import { Input, Select } from '@chakra-ui/react';
export default function Filter({ filter , setFilter}) {
    return (
        <div className='flex flex-col gap-5'>
            <Input
                placeholder='Поиск' 
                onChange={() => setFilter({...filter, search: e.target.value})}
            />
            <Select
                onChange={() => setFilter({...filter, sortOrder: e.target.value})}
            >
                <option value={"desc"}>Сначала новые</option>
                <option value={"asc"}>Сначала старые</option>
            </Select>
        </div>
    );   
}