import React, {useState} from "react";
import './App.css';
import Categories from './Categories';
import items from './data';
import Menu from './Menu';

const allCategories=["all", ...new Set(items.map((item)=>item.category))];
function App() {

  const [menuItems, setMenuItems] = useState(items);
  const [activeCategory, setActiveCategory] = useState("")
  const [categories, setCategories]=useState(allCategories);
  
  const filterItems = (category) => {
    setActiveCategory(category)
    if(category==="all"){  //kategorilerde hepsi seçiliyse
      setMenuItems(items); //tüm kayıtları göster.
      return;
    }

    const newItems = items.filter((item)=>item.category === category);
    setMenuItems(newItems);
  }
  return (
    <main>
      <section className="holiday section">
        <div className="title">
          <h2>Gezdiğim Yerler</h2>
          <div className="underline"></div>
        </div>
        <Categories categories={categories} activeCategory={activeCategory} filterItems={filterItems}/>
        <Menu items={menuItems}/>
      </section>
    </main>
  );
}

export default App;
