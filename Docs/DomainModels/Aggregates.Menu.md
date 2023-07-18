# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void removeDInner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000",
    "name": "Menu Name",
    "description": "A menu description",
    "averageRating": 3,
    "sections": [
        {
            "id": "00000000-0000-0000-0000-000000000",
            "name": "Section name",
            "description": "section description",
            "items": [
                {
                    "id": "00000000-0000-0000-0000-000000000",
                    "name": "Item Name",
                    "description": "Item description",
                    "price": 1.99
                }
            ]
        }
    ],
    "createdDateTime": "2020-01-01T00:00:00.000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.000000Z",    
    "hostId": "00000000-0000-0000-0000-000000000",
    "dinnerIds": [
        "00000000-0000-0000-0000-000000000",
        "00000000-0000-0000-0000-000000000"],
    "menuReviewIds": [
        "00000000-0000-0000-0000-000000000",
        "00000000-0000-0000-0000-000000000"],

}
```