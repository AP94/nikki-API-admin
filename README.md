# What is this?

This is an API for interacting with a database of sketches, the crafting system for the game [Infinity Nikki](https://infinitynikki.infoldgames.com).
The API can be run locally and used to update the database... by me! Only I know the password for the account with read/write access. However, the the account that is in `appsettings.json` is the read-only account, and it is also the account used for the lightweight NodeJS API found [here](https://github.com/AP94/nikki-API).
Said read-only account is:
Username: `momo`
Password: `NikkiDB2025`
For the database: `nikkidb.di0l3.mongodb.net`
and is available for anyone to use.
To build this project, nagivate to the NikkiAPI folder and run `dotnet run` in the console.

# Endpoints
## Publically available
| Method | Endpoint | Result |
| ------ | -------- | ------ |
| GET | /api/sketches | List of JSON objects |
| GET | /api/sketches/{id} | JSON object |
| GET | /api/materials | List of JSON objects |
| GET | /api/materials/{id} | JSON object |
| GET | /api/materialsources | List of JSON objects |
| GET | /api/materialsources/{id} | JSON object |

Check the Data Structures section for the structure of the JSON objects returned.

## Private
| Method | Endpoint | Body | Result |
| ------ | -------- | ---- | ------ |
| POST | /api/sketches | List of JSON objects | 201 CREATED |
| PUT | /api/sketches/{id} | JSON object representing the updated sketch; id field will be ignored | The updated JSON object |
| POST | /api/materials | List of JSON objects | 201 CREATED |
| PUT | /api/materials/{id} | JSON object representing the updated material; id field will be ignored | The updated JSON object |
| POST | /api/materialsources | List of JSON objects | 201 CREATED |
| PUT | /api/materialsources/{id} | JSON object representing the updated material source; id field will be ignored | The updated JSON object |

# Data Structures

## Sketches
```
{
  "Id": string (BSON Object ID, 24 char HEX),
  "Name": string,
  "Quality": int (2-5),
  "ThreadCost": int,
  "BlingsCost": int,
  "SketchSource": int (see section below),
  "SketchCategory": int (see section below),
  "MaterialsCost": string (see section below),
  "WardrobeCategory": int (see section below) | null
  "ClothingStyle": int (see section below) | null,
  "Labels": int[] (see section below) | null,
  "OutfitSet": int (see section below) | null,
  "FragranceType": int (see section below) | null
}
```

### SketchSource
The sketch source refers to where the sketch is obtained in the game.
| Number | Source |
| ------ | ------ |
| 0 | None |
| 1 | Chest |
| 2 | Quest |
| 3 | Event |
| 4 | Style Challenge Reward |
| 5 | Heart of Infinity |
| 6 | Kilo |
| 7 | Courses |
| 8 | Bug/Fish Quiz |
| 9 | Expeditions |

### SketchCategory
The sketch category refers to which tab the sketch can be found within the in-game sketches UI.
| Number | Category |
| ------ | -------- |
| 0 | Miracle Outfits |
| 1 | Ability Outfits |
| 2 | Stylish Outfits |
| 3 | Rare Pieces |
| 4 | Whim Fragrance |
| 5 | Momo's Cloak |

### MaterialsCost
The materials cost is a string that is to be parsed as a list of tuples. Each tuple is listed as an int and a string, which represents the amount of each material and the material's ID.
An example string is:
`"[(6, aeeb14e9cdc63056ed1e427b), (3, 477f321565c731d330933df1), (3, 58e7b587fafeeef462e2a6cc), (20, cf761a6bc5b0d340346d800d)]"`

### WardrobeCategory
For clothing pieces, the wardrobe category refers to which section in the wardrobe the piece belongs. This is an optional category.
| Number | Category |
| ------ | ------ |
| 0 | Outfits |
| 1 | Hair |
| 2 | Dresses |
| 3 | Outerwear |
| 4 | Tops |
| 5 | Bottoms |
| 6 | Socks |
| 7 | Shoes |
| 8 | Hair Accessories |
| 9 | Headwear |
| 10 | Earrings |
| 11 | Neckwear |
| 12 | Bracelets |
| 13 | Chokers |
| 14 | Gloves |
| 15 | Face Decorations |
| 16 | Chest Accessories |
| 17 | Pendants |
| 18 | Backpieces |
| 19 | Rings |
| 20 | Arm Decorations |
| 21 | Handhelds |
| 22 | Base Makeup |
| 23 | Eyebrows |
| 24 | Eyelashes |
| 25 | Contact Lenses |
| 26 | Lips |

### ClothingStyle
For clothing pieces, the clothing style refers to what style category the piece falls under for styling challenges. This is an optional category.
| Number | Style |
| ------ | ----- |
| 0 | Elegant |
| 1 | Fresh |
| 2 | Sweet |
| 3 | Sexy |
| 4 | Cool |

### Labels
For clothing pieces, the labels refer to which label(s) the piece has for styling challenges, expressed as a list of ints. This is an optional category.
| Number | Category |
| ------ | ------ |
| 0 | Warm |
| 1 | Summer |
| 2 | Home |
| 3 | Formal |
| 4 | Simple |
| 5 | Fantasy |
| 6 | Intellectual |
| 7 | Adventure |
| 8 | Romance |
| 9 | Retro |
| 10 | Fashion |
| 11 | Uniform |
| 12 | Playful |
| 13 | Trendy |
| 14 | Cute |
| 15 | Light |
| 16 | More Light |
| 17 | Fairy |
| 18 | Ballroom |
| 19 | Royal |
| 20 | Linlang |
| 21 | Pastoral |

### OutfitSet
For clothing pieces that are part of an outfit, the outfit set refer to which set the piece belongs to. This is an optional category.
| Number | Set |
| ------ | --- |
| 0 | Wishful Aurosa |
| 1 | Silvergale's Aria |
| 2 | Bubbly Voyage |
| 3 | Wind of Purity |
| 4 | Bye-Bye Dust |
| 5 | Afternoon Shine |
| 6 | Rippling Serenity |
| 7 | Fully Charged |
| 8 | Floral Memory |
| 9 | Symphony of Strings |
| 10 | Starlet Burst |
| 11 | Fiery Glow |
| 12 | Endless Longing |
| 13 | Far and Away |
| 14 | Rebirth Wish |
| 15 | Hometown Breeze |
| 16 | Starwish Echoes |
| 17 | Refined Grace |
| 18 | A Beautiful Day |
| 19 | Searching for Dreams |
| 20 | Departing Blossom |
| 21 | Carnival Ode |
| 22 | Chic Elegance |
| 23 | Scarlet Dream |

### FragranceType
For fragrances, the fragrance type refers to which slot the fragrance is equipped in. This is an optional category.
| Number | Type |
| ------ | ---- |
| 0 | Hair Oil |
| 1 | Body Spray |
| 2 | Hand Powder |

## Materials
```
{
  "Id": string (BSON Object ID, 24 char HEX),
  "Name": string,
  "MaterialType": int (see section below),
  "Quality": int (2-5),
  "SourceId": string (BSON Object ID, 24 char HEX),
  "IsEssence": boolean,
  "CrystalType": int (see section below)
}
```
SourceId refers to the ID of the material source (see below).
IsEssence is optional and defaults to false.

### MaterialType
| Number | Type |
| ------ | ---- |
| 0 | Generic |
| 1 | Harvestable |
| 2 | Bedrock Crystal |

### CrystalType
For energy crystals, this refers to the crystal type. This value is optional and defaults to 0.
| Number | Type |
| ------ | ---- |
| 0 | None |
| 1 | Energy |
| 2 | Hurl |
| 3 | Plummet |
| 4 | Tumble |
| 5 | Command |

## Material Sources
```
{
  "Id": string (BSON Object ID, 24 char HEX),
  "Name": name,
  "HarvestedBy": int (see section below),
  "Regions": int[] (see section below),
  "Locations": int[] (see section below)
}
```

### HarvestedBy
For sources that require harvesting to get materials, this refers to which type of harvesting is needed to collect it. This value is optional and defaults to 0.
| Number | Type |
| ------ | ---- |
| 0 | None |
| 1 | Collecting |
| 2 | Animal Grooming |
| 3 | Bug Catching |
| 4 | Fishing |
| 5 | Combat |

### Regions
Regions are a list of which major regions where the material source can be found. As of now, there is only one region in the game, but more will be added in the future, and it is likely that there will be plants/animals available in multiple regions, hence this value being a list.
`None` is used for sources that don't have a physical location on the map, such as the Realm of the Dark.
| Number | Region |
| ------ | ---- |
| 0 | None |
| 1 | Wishfield |

### Locations
Locations are a list of subregions on the map where the material source can be found.
| Number | Location |
| ------ | -------- |
| 0 | None |
| 1 | Quest |
| 2 | Combat |
| 3 | Warp Spire |
| 4 | Florawish |
| 5 | Breezy Meadow |
| 6 | Stoneville |
| 7 | Abandoned District |
| 8 | Wishing Woods |
| 9 | Memorial Mountains |
| 10 | Firework Isles |
